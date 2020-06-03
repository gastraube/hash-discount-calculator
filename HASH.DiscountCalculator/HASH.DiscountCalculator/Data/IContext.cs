using HASH.DiscountCalculator.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HASH.DiscountCalculator.Data
{
    public interface IContext
    {
        IMongoCollection<User> Users { get; }
        IMongoCollection<Product> Products { get; }
    }
}
