using GreatOnion.Domain.Entities.Abstracts;
using GreatOnion.Domain.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreatOnion.Domain.Entities.Concretes
{
    public class Order:BaseEntity,IEntity
    {
        public string ShippedAddress { get; set; }
        public int? AppUserID { get; set; }
       

        //Relational Properties
        public ICollection<OrderProduct> OrderProducts { get; set; }
        public AppUser AppUser { get; set; }


    }
}
