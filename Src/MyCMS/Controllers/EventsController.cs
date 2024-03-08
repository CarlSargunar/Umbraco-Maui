using Azure.Messaging.ServiceBus;
using Microsoft.AspNetCore.Mvc;
using MyCMS.Helpers;
using System.Text;
using System.Text.Json;
using Umbraco.Cms.Core.Configuration.Models;
using Umbraco.Cms.Web.Common.Controllers;

namespace MyCMS.Controllers;

public class EventsController : UmbracoApiController
{
    public ILogger<EventsController> Logger { get; }

    public EventsController(ILogger<EventsController> logger)
    {
        Logger = logger;
    }

    public async Task<IActionResult> PublishAsync([FromBody] WebhookPayload payload)
    {
        // WARNING! This is demo code - you should not create a webhook into the same 
        // website that is calling it in production code. You want to consider your own 
        // standalone API, or an Azure Function, or similar.

        if (payload is null)
            return BadRequest("No payload");

        // https://localhost:44331/Umbraco/Api/events/Publish
        Logger.LogInformation($"WebhookTest called with payload : {payload}");

        var notification = new NotificationMessage
        {
            Title = payload.Name,
            Body = $"A new article has been published: {payload.Properties.title}"
        };

        await using (ServiceBusClient client = new ServiceBusClient(DemoHelper.ServiceBusConnectionString))
        {
            // Create a sender for the queue.
            ServiceBusSender sender = client.CreateSender(DemoHelper.ServiceBusQueueName);

            // Serialize the notification object to JSON
            var json = JsonSerializer.Serialize(notification);
            var body = Encoding.UTF8.GetBytes(json);

            // Create a message that we can send. 
            ServiceBusMessage message = new ServiceBusMessage(body);

            // Send the message.
            await sender.SendMessageAsync(message);
            Logger.LogInformation($"Sent a single message to the queue: {DemoHelper.ServiceBusQueueName}");
        }

        return Ok(payload);
    }

}
