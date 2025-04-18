# Broker

Simple ASP.NET project that sets up MassTransit and RabbitMQ to publish and consume messages.

## Install Docker Windows with WSL2

`docker --version`

`docker pull rabbitmq:3-management`

## Run container

`docker run -d --name rabbitmq -p 5672:5672 -p 15672:15672 rabbitmq:3-management
docker ps`

http://localhost:15672

guest/guest

## To stop Rabbit

`docker stop rabbitmq`

## To delete the container

`docker rm rabbitmq`

## Detailed instructions

https://grok.com/share/bGVnYWN5_2bd377a4-9b5f-468f-836e-c94e21b06667