using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace J41564_CO6029_Assignment2.api.Models
{
    public class BasketItemModel
    {
        public int OrderLineID { get; set; }
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
