using HASH.DiscountCalculator.Data;
using HASH.DiscountCalculator.Models;
using HASH.DiscountCalculator.Repositories;
using HASH.DiscountCalculator.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HASH.DiscountCalculator.Tests.Services
{
    public class DiscountServiceTests
    {
        public Product testProduct = new Product()
        {
            Id = "1",
            Description = "Teste",
            Title = "Titulo Teste",
            PriceCents = 0,
            Discount = new Models.Discount() { Percentage =0,  ValueCents =0}
        };

        public User testUser = new User()
        {
            Id = "1",
            FirstName = "UserName",
            LastName = "LastName",
            BirthDate = new DateTime()
        };

        [Fact]
        public async Task CalculateDiscountNullRequestArgumentNullException()
        {
            var productRepository = new ProductRepository(null);
            var userRepository = new UserRepository(null);
            var service = new DiscountService(productRepository, userRepository);

            await Assert.ThrowsAsync<ArgumentNullException>(() => service.CalculateDiscount(null, null));
        }

        [Fact]
        public async Task CalculateDiscountNullRequestProductIdArgumentNullException()
        {
            var productRepository = new ProductRepository(null);
            var userRepository = new UserRepository(null);
            var service = new DiscountService(productRepository, userRepository);
            var request = new ProductLookUpModel();
            request.ProductId = "";
            request.UserId = "1";
            request.TodayDate = "2020-05-01";

            await Assert.ThrowsAsync<ArgumentNullException>(() => service.CalculateDiscount(request, null));
        }

        [Fact]
        public async Task CalculateDiscountNullRequestUserIdArgumentNullException()
        {
            var productRepository = new ProductRepository(null);
            var userRepository = new UserRepository(null);
            var service = new DiscountService(productRepository, userRepository);
            var request = new ProductLookUpModel();
            request.ProductId = "1";
            request.UserId = "";
            request.TodayDate = "2020-05-01";

            await Assert.ThrowsAsync<ArgumentNullException>(() => service.CalculateDiscount(request, null));
        }


        [Fact]
        public async Task CalculateDiscountNullRequestTodayDateArgumentNullException()
        {
            var mock = new Mock<IProductRepository>();
            var mock2 = new Mock<IUserRepository>();

            mock.Setup(u => u.GetProductById(It.IsAny<string>()))
                .Returns(Task.FromResult(testProduct));

            mock2.Setup(u => u.GetUserById(It.IsAny<string>()))
                .Returns(Task.FromResult(testUser));

            var service = new DiscountService(mock.Object, mock2.Object);

            var request = new ProductLookUpModel();
            request.ProductId = "1";
            request.UserId = "1";
            request.TodayDate = "";

            await Assert.ThrowsAsync<ArgumentNullException>(() => service.CalculateDiscount(request, null));
        }

        [Fact]
        public async Task CalculateDiscountProductCannotBeNull()
        {
            var mock = new Mock<IProductRepository>();
            var mock2 = new Mock<IUserRepository>();

            mock.Setup(u => u.GetProductById(It.IsAny<string>()))
                .Returns(Task.FromResult(testProduct));

            mock2.Setup(u => u.GetUserById(It.IsAny<string>()))
                .Returns(Task.FromResult(testUser));

            var service = new DiscountService(mock.Object, mock2.Object);
            var request = new ProductLookUpModel();
            request.ProductId = "1";
            request.UserId = "1";
            request.TodayDate = "2020-05-01";

            var product = await service.CalculateDiscount(request, null);

            Assert.True(product != null);
        }

        [Fact]
        public async Task GetProductByIdProductNotFoundArgumentNullException()
        {

            var mock = new Mock<IProductRepository>();

            mock.Setup(u => u.GetProductById(It.IsAny<string>()))
                .Returns(Task.FromResult<Product>(null));

            var userRepository = new UserRepository(null);
            var service = new DiscountService(mock.Object, userRepository);
            var request = new ProductLookUpModel();
            request.ProductId = "1";
            request.UserId = "1";
            request.TodayDate = "2020-05-01";

            await Assert.ThrowsAsync<ArgumentNullException>(() => service.GetProductById("1"));
        }


        [Fact]
        public async Task GetUserByIdUserNotFoundArgumentNullException()
        {

            var mock = new Mock<IUserRepository>();

            mock.Setup(u => u.GetUserById(It.IsAny<string>()))
                .Returns(Task.FromResult<User>(null));

            var productRepository = new ProductRepository(null);
            var service = new DiscountService(productRepository, mock.Object);
            var request = new ProductLookUpModel();
            request.ProductId = "1";
            request.UserId = "1";

            await Assert.ThrowsAsync<ArgumentNullException>(() => service.GetUserById("1"));
        } 
    }
}
