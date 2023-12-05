
using GreatOnion.Domain.Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreatOnion.Persistence.Seed
{
    public static class DataSeedExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(GenerateFakeData.GenerateCategoryData());
            modelBuilder.Entity<Product>().HasData(GenerateFakeData.GenerateProductData());
        }
    }
}
