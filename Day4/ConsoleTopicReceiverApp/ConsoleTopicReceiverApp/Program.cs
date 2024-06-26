﻿using Azure.Messaging.ServiceBus;
using ConsoleTopicReceiverApp;
using Newtonsoft.Json;
using ConsoleTopicReceiverApp;


string connectionString = "Endpoint=sb://day4sbns.servicebus.windows.net/;SharedAccessKeyName=readwritePolicy;SharedAccessKey=zHCIGuU4uOCka8f420/W912BTPQaDXnGn+ASbOPDzAw=;EntityPath=orders";
string topicName = "orders";
string subscriptionName = "subB";//change to ConsumerA,ConsumerB,ConsumerC

await ReceiveMessages();

async Task ReceiveMessages()
{
    ServiceBusClient serviceBusClient = new ServiceBusClient(connectionString);
    ServiceBusReceiver serviceBusReceiver = serviceBusClient.CreateReceiver(topicName, subscriptionName,
        new ServiceBusReceiverOptions() { ReceiveMode = ServiceBusReceiveMode.ReceiveAndDelete });

    IAsyncEnumerable<ServiceBusReceivedMessage> messages = serviceBusReceiver.ReceiveMessagesAsync();

    await foreach (ServiceBusReceivedMessage message in messages)
    {

        Stock order = JsonConvert.DeserializeObject<Stock>(message.Body.ToString());
        Console.WriteLine("Order Id {0}", order.OrderID);
        Console.WriteLine("Quantity {0}", order.Quantity);
        Console.WriteLine("Unit Price {0}", order.UnitPrice);
        Console.WriteLine();
        //await Console.Out.WriteLineAsync();

    }
}
