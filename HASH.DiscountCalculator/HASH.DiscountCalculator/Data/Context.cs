using HASH.DiscountCalculator.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HASH.DiscountCalculator.Data
{
    public class Context : IContext
    {
        private readonly IMongoDatabase database;        

        public Context(string port, string host)
        {
            database = new MongoClient($"mongodb://{host}:{port}").GetDatabase("DiscountCalculator");
        }

        public IMongoCollection<Product> Products
        {
            get {
                return database.GetCollection<Product>("Products");
            }
        }

        public IMongoCollection<User> Users
        {
            get
            {
                return database.GetCollection<User>("Users");
            }
        }
    }
}
