# Broker

---

This project provides an example of integrating MassTransit and RabbitMQ within an ASP.NET application to enable message-based communication and saga orchestration.

## Install Docker on Windows with WSL2

To verify Docker is installed, run:

`docker --version`

Then, pull the RabbitMQ image:

`docker pull rabbitmq:3-management`

---

## Run RabbitMQ Container

Start the container with the following command:

`docker run -d --name rabbitmq -p 5672:5672 -p 15672:15672 rabbitmq:3-management
docker ps`

Check if the container is running:

`docker ps`

RabbitMQ web management console:

[http://localhost:15672](http://localhost:15672)

Login credentials: 

> Username: *guest* <br> Password: *guest*

---

## Stop or Remove RabbitMQ

To stop RabbitMQ:

`docker stop rabbitmq`

To delete the container:

`docker rm rabbitmq`

---

## Creating an Order and Starting the Saga

To initiate the process, send a POST request to:

`POST /Orders`

This creates an order object with a randomly generated GUID.

---

## Manually Trigger a Response to Complete the Saga

To simulate the necessary message that finalizes the saga, send a POST request to:

`POST /Orders/SimulateResponse`

Ensure the GUID matches the one generated in the previous step.

---

## Detailed Instructions

For more information, refer to:

https://grok.com/share/bGVnYWN5_2bd377a4-9b5f-468f-836e-c94e21b06667

