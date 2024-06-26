﻿using System;
using System.Text;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Producer;
class Program
{


    private const string connectionString = "Endpoint=sb://day5eventns.servicebus.windows.net/;SharedAccessKeyName=readwrite;SharedAccessKey=pCEWsiaMk6579h1YXMk8ERxOOCrOdeuG4+AEhDtHVYk=;EntityPath=apphub";
    private const string eventHubName = "apphub";
    static async Task Main()
    {
        // Create a producer client that you can use to send events to an event hub
        await using (var producerClient = new EventHubProducerClient(connectionString, eventHubName))
        {

            while (true)
            { // Create a batch of events
                using EventDataBatch eventBatch = await producerClient.CreateBatchAsync();
                // Add events to the batch. An event is a represented by a collection of bytes and metadata.
                string time = DateTime.Now.ToLongTimeString();
                eventBatch.TryAdd(new EventData(Encoding.UTF8.GetBytes("First event at " + time)));
                eventBatch.TryAdd(new EventData(Encoding.UTF8.GetBytes("Second event " + time)));
                eventBatch.TryAdd(new EventData(Encoding.UTF8.GetBytes("Third event " + time)));
                // Use the producer client to send the batch of events to the event hub
                await producerClient.SendAsync(eventBatch);
                Console.WriteLine("A batch of 3 events has been published at " + time + "...Press enter for next batch");
                Console.ReadLine();
            }
        }
    }
}