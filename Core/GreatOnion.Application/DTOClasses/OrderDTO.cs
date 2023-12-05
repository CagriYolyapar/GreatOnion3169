using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreatOnion.Application.DTOClasses
{
    public class OrderDTO:BaseDTO
    {
        public string ShippedAddress { get; set; }
        public int? AppUserID { get; set; }
    }
}
