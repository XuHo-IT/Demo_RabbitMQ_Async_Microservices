using EmailNotificationWehook.Consumer;
using EmailNotificationWehook.Service;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Shared.DTOs;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpClient();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<WebHookConsumer>();
    x.UsingRabbitMq((context, config) =>
    {
        config.Host("rabbitmq://localhost", credential =>
        {
            credential.Username("guest");
            credential.Password("guest");
        });
        config.ReceiveEndpoint("email-webhook-queue", e =>
        {
            e.ConfigureConsumer<WebHookConsumer>(context);
        });
    });
});

var app = builder.Build();

app.MapPost("/email-webhook", ([FromBody] EmailDTO email, IEmailService emailService) =>
{
    string result = emailService.SendEmail(email);
    return Task.FromResult(result);
});

app.Run();
