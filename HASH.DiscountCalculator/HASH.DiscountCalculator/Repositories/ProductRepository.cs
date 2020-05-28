using HASH.DiscountCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HASH.DiscountCalculator.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private List<Product> productsList = new List<Product>() {
            new Product()
            {
                Id = "1",
                Description = "Copo Plástico, vermelho, 200ml",
                PriceCents = 10,
                Title = "Copo Plástico"
            }            
        };
        
        public Task<Product> GetProductById(string productId)
        {                    
            return Task.FromResult(
                productsList.Where(product => product.Id == productId).FirstOrDefault()
            );
        }

    }
}
