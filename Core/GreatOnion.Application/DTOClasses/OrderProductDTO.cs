using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreatOnion.Application.DTOClasses
{
    public class OrderProductDTO:BaseDTO
    {
        public int OrderID { get; set; }
        public int ProductID { get; set; }
    }
}
