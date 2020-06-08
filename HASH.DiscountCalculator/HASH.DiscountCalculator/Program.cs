using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using HASH.DiscountCalculator.Repositories;
using HASH.DiscountCalculator.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace HASH.DiscountCalculator
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var configuration = new ConfigurationBuilder().AddEnvironmentVariables().Build();
            var Port = int.Parse(configuration.GetValue<string>("PORT") ?? "50051");
            var Host = configuration.GetValue<string>("HOST") ?? "localhost";
            var MongoPort = configuration.GetValue<string>("MONGO_PORT") ?? "27017";
            var MongoHost = configuration.GetValue<string>("MONGO_HOST") ?? "localhost";

            var context = new Data.Context(MongoPort, MongoHost);
            var productRepository = new ProductRepository(context);
            var userRepository = new UserRepository(context);            

            Server server = new Server
            {
                Services = { Discount.BindService(new DiscountService(productRepository, userRepository)) },
                Ports = { new ServerPort(Host, Port, ServerCredentials.Insecure) }
            };
            server.Start();

            Console.WriteLine("Server listening on port " + Port);        
            Console.WriteLine("Press any key to stop the server...");
            Console.ReadKey();

            server.ShutdownAsync().Wait();
            
        }
    }
}
