using HASH.DiscountCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HASH.DiscountCalculator.Repositories
{
    public interface IProductRepository
    {
        Task<Product> GetProductById(string productId);
        Task<List<Product>> GetAllProducts();
    }
}
