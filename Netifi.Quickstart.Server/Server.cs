using System;
using System.Buffers;
using System.Collections.Generic;
using System.Threading.Tasks;
using RSocket;
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
			var client = new Broker.Client.BrokerClient(accessKey, accessToken, null, null, "quickstart.services.helloservices", "serviceName", 0, new SortedDictionary<string, string>(), transport, RSocketOptions.Default);

			// Connect to Netifi Platform
			await client.ConnectAsync();

            
		}
    }
}
