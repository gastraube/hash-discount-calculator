using HASH.DiscountCalculator.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HASH.DiscountCalculator.Tests.Services
{
    public class ProductTests
    {
        [Fact]
        public void NewProductHasANewDiscount()
        {
            var product = new Product();

            Assert.True(product.Discount != null);
        }

        [Fact]
        public void CheckBirthDayDiscountReturnedDiscountCannotBeZero()
        {
            var product = new Product();
            product.PriceCents = 1000;
            product.CheckBirthDayDiscount(DateTime.Now.Date, DateTime.Now.Date);

            Assert.NotEqual(0, product.Discount.ValueCents);
            Assert.NotEqual(0, product.Discount.Percentage);
        }

        [Fact]
        public void CheckBlackFridayDiscountReturnedDiscountCannotBeZero()
        {
            var product = new Product();
            product.PriceCents = 1000;
            product.CheckBlackFridayDiscount(new DateTime(2019, 11, 25));

            Assert.NotEqual(0, product.Discount.ValueCents);
            Assert.NotEqual(0, product.Discount.Percentage);
        }

        [Fact]
        public void CheckDiscountLimitReturnZero()
        {
            var product = new Product();
            product.Discount.Percentage = 0.2F;
            product.CheckDiscountLimit();

            Assert.Equal(0, product.Discount.ValueCents);
            Assert.Equal(0, product.Discount.Percentage);
        }
    }
}
