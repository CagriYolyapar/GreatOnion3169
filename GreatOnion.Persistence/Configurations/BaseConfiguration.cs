using GreatOnion.Domain.Entities.Abstracts;
using GreatOnion.Domain.Entities.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreatOnion.Persistence.Configurations
{
    public class BaseConfiguration<T> : IEntityTypeConfiguration<T> where T : class, IEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(x => x.Status).HasColumnName("DataStatus");
            builder.Property(x => x.CreatedDate).HasColumnName("Inserted Date");
            builder.Property(x => x.ModifiedDate).HasColumnName("Updated Date");
            builder.Property(x => x.DeletedDate).HasColumnName("Passification Date");
        }
    }
}
