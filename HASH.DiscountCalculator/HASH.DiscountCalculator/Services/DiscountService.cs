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
        private readonly IProductRepository _productRepository;
        private readonly IUserRepository _userRepository;

        public DiscountService(IProductRepository productRepository, IUserRepository userRepository)
        {            
            _productRepository = productRepository;
            _userRepository = userRepository;
        }

        public override async Task GetAllProducts(ProductsRequest request,
            IServerStreamWriter<ProductModel> responseStream,
            ServerCallContext context)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var products = await GetAllProducts();

            foreach (var product in products)
            {
                await Task.Delay(1000);
                var productModel = product.ParseToProductModel();
                await responseStream.WriteAsync(productModel);
            }
        }

        public override async Task GetAllUsers(UsersRequest request,
         IServerStreamWriter<UserModel> responseStream,
         ServerCallContext context)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var users = await GetAllUsers();

            foreach (var user in users)
            {
                await Task.Delay(1000);
                var userModel = user.ParseToUserModel();
                await responseStream.WriteAsync(userModel);
            }
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

        public async Task<List<Product>> GetAllProducts()
        {
            var products = await _productRepository.GetAllProducts();

            if (products.Count == 0)
                throw new ArgumentNullException($"No products found");

            return products;
        }

        public async Task<List<User>> GetAllUsers()
        {
            var users = await _userRepository.GetAllUsers();

            if (users.Count == 0)
                throw new ArgumentNullException($"No users found");

            return users;
        }
    }
}
