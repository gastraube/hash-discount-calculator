using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Grpc.Core;
using HASH.DiscountCalculator.Models;
using HASH.DiscountCalculator.Repositories;
using Microsoft.Extensions.Logging;

namespace HASH.DiscountCalculator.Services
{
    public class DiscountService : Discount.DiscountBase
    {
        private readonly ILogger<DiscountService> _logger;
        private readonly IProductRepository _productRepository;
        private readonly IUserRepository _userRepository;

        public DiscountService(IProductRepository productRepository, IUserRepository userRepository)
        {            
            _productRepository = productRepository;
            _userRepository = userRepository;
        }

        public override async Task<ProductModel> CalculateDiscount(ProductLookUpModel request, ServerCallContext context)
        {          
            var product = await GetProductById(request.ProductId);
            var user = await GetUserById(request.UserId);

            var prod = CalculateProducstDiscount(product, user);

            return prod;
        }

        private ProductModel CalculateProducstDiscount(Product product, User user)
        {
            product.CheckBirthDayDiscount(user.BirthDate);
            product.CheckBlackFridayDiscount();
            product.CheckDiscountLimit();

            return product.ParseToProductModel();
        }

        private async Task<Product> GetProductById(string productId)
        {
            return await _productRepository.GetProductById(productId);
        }

        private async Task<User> GetUserById(string userId)
        {
            return await _userRepository.GetUserById(userId);
        }
        
    }
}
