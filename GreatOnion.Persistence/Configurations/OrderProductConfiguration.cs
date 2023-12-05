
using GreatOnion.Domain.Entities.Concretes;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreatOnion.Persistence.Configurations
{
    public class OrderProductConfiguration:BaseConfiguration<OrderProduct>
    {
        public override void Configure(EntityTypeBuilder<OrderProduct> builder)
        {
            base.Configure(builder);

            builder.Ignore(x => x.ID);

            builder.HasKey(x => new
            {
                x.OrderID,
                x.ProductID
            });
        }
    }
}
