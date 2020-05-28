using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;

namespace HASH.DiscountCalculator.Services
{
    public class DiscountService : Discount.DiscountBase
    {
        private readonly ILogger<DiscountService> _logger;
        public DiscountService(ILogger<DiscountService> logger)
        {
            _logger = logger;
        }

        public override Task<ProductModel> CalculateDiscount(ProductLookUpModel request, ServerCallContext context)
        {          
            var product = SearchProduct(request);

            var productWithDiscount = CalculateProsductDiscount(product, request);

            return Task.FromResult(product);
        }

        private object CalculateProsductDiscount(ProductModel product, ProductLookUpModel request)
        {
            throw new NotImplementedException();
        }

        private ProductModel SearchProduct(ProductLookUpModel request)
        {
            var product1 = new ProductModel()
            {
                Id = "1",
                Description = "Copo Plástico, vermelho, 200ml",
                PriceInCents = 10,
                Title = "Copo Plástico"
            };

            var productsList = new List<ProductModel>();
            productsList.Add(product1);

            var product = productsList.Where(product => product.Id == request.ProductId).FirstOrDefault();

            return product;
        }
    }
}
