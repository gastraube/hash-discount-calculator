using HASH.DiscountCalculator.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HASH.DiscountCalculator.Data
{
    public class Context
    {
        private readonly IMongoDatabase database;

        public Context()
        {
            database = new MongoClient("mongodb://localhost:27017").GetDatabase("DiscountCalculator");
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
