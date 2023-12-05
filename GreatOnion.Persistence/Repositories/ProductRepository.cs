using GreatOnion.Domain.Entities.Concretes;
using GreatOnion.Domain.Repositories;
using GreatOnion.Persistence.ContextClasses;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreatOnion.Persistence.Repositories
{
    public class ProductRepository:BaseRepository<Product>,IProductRepository
    {
        public ProductRepository(AppDbContext context):base(context)
        {

        }

        public async Task<List<Product>> GetProductsWithCategoriesAsync()
        {
            return await GetActivesAsIQueryableAsync().Include(x => x.Category).ToListAsync();
        }
    }
}
