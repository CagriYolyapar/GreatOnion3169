using GreatOnion.Domain.Entities.Concretes;
using GreatOnion.Domain.Repositories;
using GreatOnion.Persistence.ContextClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreatOnion.Persistence.Repositories
{
    public class OrderRepository:BaseRepository<Order>,IOrderRepository
    {
        public OrderRepository(AppDbContext context):base(context)
        {

        }
    }
}
