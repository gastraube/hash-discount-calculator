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
                Description = "Copo Plástico, vermelho, 200ml.",
                PriceCents = 10,
                Title = "Copo Plástico"
            },
            new Product()
            {
                Id = "2",
                Description = "iPhone 11 Pro Max novo na caixa.",
                PriceCents = 1000,
                Title = "iPhone 11"
            },
            new Product()
            {
                Id = "3",
                Description = "Relógio de pulso, preto.",
                PriceCents = 150,
                Title = "Relógio"
            },
            new Product()
            {
                Id = "4",
                Description = "Monitor LED 30 polegadas.",
                PriceCents = 3000,
                Title = "Monitor LED"
            },            
            new Product()
            {
                Id = "5",
                Description = "Tênis de corrida, preto, Nike.",
                PriceCents = 570,
                Title = "Tênis de Corrida"
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
