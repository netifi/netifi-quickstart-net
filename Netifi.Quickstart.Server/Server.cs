using System;
using System.Buffers;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using RSocket;
using RSocket.RPC;
using RSocket.Transports;
using Com.Netifi.Quickstart.Service;

namespace Netifi.Quickstart
{
    public class Server
    {
        static async Task Main(string[] args)
        {
			var serviceName = "helloservice-" + Guid.NewGuid().ToString();

			// Build Netifi Broker Connection
			var accessKey = 9007199254740991;
			var accessToken = "kTBDVtfRBO4tHOnZzSyY5ym2kfY=";
			var transport = new SocketTransport("tcp://localhost:8001/");
			var client = new Broker.Client.BrokerClient(accessKey, accessToken, null, null, "quickstart.services.helloservices", "helloservice", 0, new SortedDictionary<string, string>(), transport, RSocketOptions.Default);

            // Add Service to Respond to Requests
            var service = new DefaultHelloService();
            client.AddService(service);

            // Connect to Netifi Platform
            await client.ConnectAsync();

            // Keep the Service Running
            await Task.Delay(Timeout.Infinite);
		}
    }
}
