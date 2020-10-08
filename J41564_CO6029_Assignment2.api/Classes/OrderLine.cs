using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace J41564_CO6029_Assignment2.api.Classes
{
    public class OrderLine
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public ICollection<Product> Products { get; set; }
        public decimal ProductPrice = 0;
    }
}
