using GreatOnion.Domain.Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreatOnion.Persistence.Configurations
{
    public class CategoryConfiguration:BaseConfiguration<Category>
    {
        public override void Configure(EntityTypeBuilder<Category> builder)
        {
            base.Configure(builder);
            builder.ToTable("Categories")
                .HasMany(x=>x.Products)
                .WithOne(x=>x.Category)
                .HasForeignKey(x=>x.CategoryID)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
