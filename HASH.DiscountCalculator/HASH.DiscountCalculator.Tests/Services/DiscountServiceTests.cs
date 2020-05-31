using HASH.DiscountCalculator.Repositories;
using HASH.DiscountCalculator.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HASH.DiscountCalculator.Tests.Services
{
    public class DiscountServiceTests
    {
        [Fact]
        public async Task CalculateDiscountNullRequestArgumentNullException()
        {
            var productRepository = new ProductRepository();
            var userRepository = new UserRepository();
            var service = new DiscountService(productRepository, userRepository);

            await Assert.ThrowsAsync<ArgumentNullException>(() => service.CalculateDiscount(null, null));
        }
    }
}
