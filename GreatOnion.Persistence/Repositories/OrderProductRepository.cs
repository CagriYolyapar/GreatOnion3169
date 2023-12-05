﻿using GreatOnion.Domain.Entities.Concretes;
using GreatOnion.Domain.Repositories;
using GreatOnion.Persistence.ContextClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreatOnion.Persistence.Repositories
{
    public class OrderProductRepository:BaseRepository<OrderProduct>,IOrderProductRepository
    {
        public OrderProductRepository(AppDbContext context):base(context) 
        {

        }
    }
}
