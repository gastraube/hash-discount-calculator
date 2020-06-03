using HASH.DiscountCalculator.Data;
using HASH.DiscountCalculator.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HASH.DiscountCalculator.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IContext _context;

        public ProductRepository(IContext context)
        {
            _context = context;
        }
        
        public async Task<Product> GetProductById(string productId)
        {
            var product = await _context.Products.Find(p => p.Id == productId).FirstOrDefaultAsync();

            return product;
        }

        public async Task<List<Product>> GetAllProducts()
        {
            var products = await _context.Products.Find(_ => true).ToListAsync();

            return products;
        }

    }
}
