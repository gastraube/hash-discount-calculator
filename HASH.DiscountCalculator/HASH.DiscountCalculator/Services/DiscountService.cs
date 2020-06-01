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

            if (request == null)
                throw new ArgumentNullException(nameof(request));

            if (string.IsNullOrEmpty(request.ProductId))           
                throw new ArgumentNullException(nameof(request.ProductId));

            if (string.IsNullOrEmpty(request.UserId))
                throw new ArgumentNullException(nameof(request.UserId));


            var product = await GetProductById(request.ProductId);
            var user = await GetUserById(request.UserId);

            CalculateProducstDiscount(product, user);

            return product.ParseToProductModel();
        }

        private Product CalculateProducstDiscount(Product product, User user)
        {
            try
            {
                if (user.BirthDate == null)
                    throw new ArgumentNullException(nameof(user.BirthDate));

                product.CheckBirthDayDiscount(user.BirthDate);
                product.CheckBlackFridayDiscount(DateTime.Now.Date);
            }
            catch (Exception)
            {
                ResetDiscounts(product);
            }
            
            return product;
        }

        private Product ResetDiscounts(Product product)
        {
            product.Discount.Percentage = 0;
            product.Discount.ValueCents = 0;

            return product;
        }

        public async Task<Product> GetProductById(string productId)
        {
            var product = await _productRepository.GetProductById(productId);

            if (product == null)
                throw new ArgumentNullException($"Product with id: {productId} not found");

            return product;
        }

        public async Task<User> GetUserById(string userId)
        {
            var user = await _userRepository.GetUserById(userId);

            if (user == null)
                throw new ArgumentNullException($"User with id: {user} not found");

            return user;
        }
    }
}
