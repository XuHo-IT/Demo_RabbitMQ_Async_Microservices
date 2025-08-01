This project demonstrates an asynchronous microservices architecture using RabbitMQ and MassTransit in .NET. 
The system includes services that communicate through message queues and respond to events by triggering webhooks.

💡 Project Description
The system is made up of multiple microservices that communicate asynchronously using RabbitMQ as a message broker.
This design allows services to operate independently while exchanging messages through MassTransit, a .NET messaging library.

A typical use case in this project involves a service publishing an event (e.g., user registration or order placed)
, and another service consuming that event to perform a task, such as sending a notification or triggering an external webhook.

🧠 Webhook Integration
A webhook is used to send real-time HTTP requests from the consumer service to another system when a specific event occurs.
This enables immediate communication between internal or external systems without polling or manual triggers.
