using GreatOnion.Domain.Entities.Abstracts;
using GreatOnion.Domain.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreatOnion.Domain.Entities.Concretes
{
    public class Category:BaseEntity,IEntity
    {
        public string CategoryName { get; set; }
        public string? Description { get; set; }

        //Relational Properties
        public ICollection<Product> Products { get; set; }


    }
}
