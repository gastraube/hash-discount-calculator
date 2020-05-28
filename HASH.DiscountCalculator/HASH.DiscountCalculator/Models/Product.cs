﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HASH.DiscountCalculator.Models
{
    public class Product
    {
        public Product()
        {
            Discount = new Discount();
        }

        public string Id { get; set; }
        public int PriceCents { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Discount Discount { get; set; }

        public void CheckBirthDayDiscount(DateTime userBirthDay)
        {
            if (userBirthDay == DateTime.Now) {
                Discount.Percentage = 0.05F;
                Discount.ValueCents = (int)(PriceCents * Discount.Percentage);              
            }                
        }

        public void CheckBlackFridayDiscount()
        {
            if (DateTime.Now.Day == Dates.BlackFridayDay && DateTime.Now.Month == Dates.BlackFridayMonth)
            {
                Discount.Percentage = 0.1F;
                Discount.ValueCents = (int)(PriceCents * Discount.Percentage);
            }
        }

        public void CheckDiscountLimit()
        {
            if (Discount.Percentage > 0.1F)
            {
                Discount.Percentage = 0;
                Discount.ValueCents = 0;
            }
        }

        public ProductModel ParseToProductModel()
        {
            return new ProductModel()
            {
                Id = Id,
                PriceInCents = PriceCents,
                Title = Title,
                Description = Description,
                Discount = new DiscountModel()
                {
                    Pct = Discount.Percentage,
                    ValueInCents = Discount.ValueCents
                }
            };
        }
    }
}
