using System;
using System.Threading.Tasks;
using Azure.Messaging.WebPubSub;

namespace publisher
{
    class Program
    {
        static async Task Main(string[] args)
        {
            if (args.Length != 3)
            {
                Console.WriteLine("Usage: publisher <connectionString> <hub> <message>");
                return;
            }
            var connectionString = args[0];
            var hub = args[1];
            var message = args[2];

            var serviceClient = new WebPubSubServiceClient(connectionString, hub);

            // Send messages to all the connected clients
            // You can also try SendToConnectionAsync to send messages to the specific connection
            await serviceClient.SendToAllAsync(message);
        }
    }
}