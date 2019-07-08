using System;
using System.Buffers;
using System.Collections.Generic;
using System.Threading.Tasks;
using Com.Netifi.Quickstart.Service;

namespace Netifi.Quickstart
{
    public class DefaultHelloService: HelloService.HelloServiceServer
    {
        public override Task<HelloResponse> SayHello(HelloRequest message, ReadOnlySequence<byte> metadata)
        {
            Console.WriteLine($"received a message -> {message.Name}");
            var response = new HelloResponse();
            response.Message = "Hello, " + message.Name;
            return Task.FromResult(response);
        }
    }
}
