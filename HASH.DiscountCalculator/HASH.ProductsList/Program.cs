using Grpc.Net.Client;
using HASH.DiscountCalculator;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace HASH.ProductsList
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var input = new ProductLookUpModel() { ProductId = "1", UserId = "1" };

            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new Discount.DiscountClient(channel);

            var reply = await client.CalculateDiscountAsync(input);

            Console.WriteLine(JsonConvert.SerializeObject(reply));
            Console.ReadLine();
        }
    }
}
