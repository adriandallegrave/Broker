using Broker.Dtos;
using MassTransit;

namespace Broker.Saga;

public class ProcessingSaga : MassTransitStateMachine<ProcessingSagaState>
{
    public State Processing { get; private set; }
    public State Completed { get; private set; }

    public Event<StartProcessingEvent> StartProcessing { get; private set; }
    public Event<ResponseEvent> ResponseReceived { get; private set; }

    public ProcessingSaga()
    {
        InstanceState(x => x.CurrentState);

        Event(() => StartProcessing, x => x.CorrelateById(context => context.Message.Id));
        Event(() => ResponseReceived, x => x.CorrelateById(context => context.Message.Id));

        Initially(
            When(StartProcessing)
                .Then(context =>
                {
                    context.Saga.CorrelationId = context.Message.Id;
                    context.Saga.Description = context.Message.Description;
                    Console.WriteLine($"Saga state: [{context.Saga.CurrentState}] - Id: [{context.Message.Id}]");
                })
                .Publish(context => new OutboundEvent
                {
                    Id = context.Message.Id
                })
                .TransitionTo(Processing));

        During(Processing,
            When(ResponseReceived)
                .Then(context =>
                {
                    context.Saga.ResponseDescription = context.Message.Description;
                    Console.WriteLine($"Saga state: [{context.Saga.CurrentState}] - Id: [{context.Message.Id}]");
                })
                .TransitionTo(Completed)
                .Finalize()
                .Then(context => Console.WriteLine($"Saga state: [{context.Saga.CurrentState}] - Id: [{context.Message.Id}]")));

        SetCompletedWhenFinalized();
    }
}

public class ProcessingSagaState : SagaStateMachineInstance
{
    public Guid CorrelationId { get; set; }
    public string CurrentState { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string ResponseDescription { get; set; } = string.Empty;
}
