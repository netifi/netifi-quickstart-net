using System;
using System.Buffers;
using System.Collections.Generic;
using System.Threading.Tasks;
using RSocket;
using RSocket.Transports;
using Com.Netifi.Quickstart.Service;

namespace Netifi.Quickstart
{
    public class Client
    {
        static async Task Main(string[] args)
        {
            // Build Netifi Broker Connection
            var accessKey = 9007199254740991;
            var accessToken = "kTBDVtfRBO4tHOnZzSyY5ym2kfY=";
            var transport = new SocketTransport("tcp://localhost:8001/");
            var client = new Broker.Client.BrokerClient(accessKey, accessToken, null, null, "quickstart.clients", "client", 0, new SortedDictionary<string, string>(), transport, RSocketOptions.Default);

            // Connect to Netifi Platform
            await client.ConnectAsync();

            // Create Client to Communicate with the HelloService (included example service)
            var group = client.Group("quickstart.services.helloservices", new SortedDictionary<string, string>());
            var helloService = new HelloService.HelloServiceClient(group);

            // Create Request to HelloService
            var request = new HelloRequest();
            request.Name = "World";

            Console.WriteLine("Sending 'World' to HelloService...");

            // Call the HelloService
            var response = await helloService.SayHello(request, new ReadOnlySequence<byte>());
            Console.WriteLine(response.Message);
        }
    }
}
