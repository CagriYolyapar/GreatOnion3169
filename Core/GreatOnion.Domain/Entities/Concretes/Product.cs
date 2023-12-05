using GreatOnion.Domain.Entities.Abstracts;
using GreatOnion.Domain.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreatOnion.Domain.Entities.Concretes
{
    public class Product:BaseEntity,IEntity
    {
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int? CategoryID { get; set; }


        //Relational Properties
        public Category Category { get; set; }
        public ICollection<OrderProduct> OrderProducts { get; set; }

    }
}
