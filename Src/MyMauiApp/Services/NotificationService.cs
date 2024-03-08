using Azure.Messaging.ServiceBus;
using Azure.Messaging.ServiceBus.Administration;
using MyMauiApp.Helpers;
using Plugin.LocalNotification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MyMauiApp.Services
{
    public class NotificationService
    {

        private readonly TimeSpan _pollingInterval;


        public NotificationService()
        {
            _pollingInterval = TimeSpan.FromSeconds(1);
        }

        public async Task<NotificationMessage> StartPollingAsync()
        {
            await using var client = new ServiceBusClient(DemoHelpers.ServiceBusConnectionString);
            await using var receiver = client.CreateReceiver(DemoHelpers.ServiceBusQueueName);

            var cancellationToken = new CancellationToken();

            // Receive a single message
            ServiceBusReceivedMessage message = await receiver.ReceiveMessageAsync(_pollingInterval, cancellationToken);
            try
            {
                if (message != null)
                {
                    // Deserialize the message body to NotificationMessage
                    var body = Encoding.UTF8.GetString(message.Body);
                    var notification = JsonSerializer.Deserialize<NotificationMessage>(body);

                    // Process the deserialized message
                    Console.WriteLine($"Received message: {notification.Title} - {notification.Body}");

                    return notification;

                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions
                Console.WriteLine($"Error processing message: {ex.Message}");
            }
            finally
            {
                if (message != null)
                {
                    // Remove the message from the queue
                    await receiver.CompleteMessageAsync(message);
                }
            }
            return null;
        }
    }
}
