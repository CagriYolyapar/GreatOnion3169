using Bogus;
using GreatOnion.Domain.Entities.Concretes;
using GreatOnion.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GreatOnion.Persistence.Seed
{
    public static class GenerateFakeData
    {
        #region Categories
        public static List<Category> GenerateCategoryData()
        {
            int categoryId = 0;
            Faker<Category> categoryFaker = new();
            categoryFaker.StrictMode(false)
                .RuleFor(x => x.ID, x => categoryId++)
                .RuleFor(x=>x.CategoryName,x => x.Commerce.Categories(1).First())
                .RuleFor(x=>x.Status,x => DataStatus.Inserted)
                .RuleFor(x=>x.CreatedDate, x => DateTime.Now); //Araştır!!! true argümanında avantaj var mı diye bak!!
            return categoryFaker.Generate(10);

        }



        #endregion

        #region Products
        public static List<Product> GenerateProductData()
        {
            int productId = 0;
            Faker<Product> productFaker = new();
            productFaker.StrictMode(false)
                .RuleFor(x => x.ID, x => productId++)
                .RuleFor(x => x.ProductName, x => x.Commerce.ProductName())
                .RuleFor(x => x.CreatedDate, x => DateTime.Now)
                .RuleFor(x => x.UnitPrice, x => Convert.ToDecimal(x.Commerce.Price(1, 100)))
                .RuleFor(x => x.Status, x => DataStatus.Inserted)
                .RuleFor(x => x.CategoryID, x => productId++);

            return productFaker.Generate(10);
        }
        #endregion
    }
}
