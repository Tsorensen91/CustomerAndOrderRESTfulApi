using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace J41564_CO6029_Assignment2.api.Classes
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string CreatedDate { get; set; }
        public string DispatchedDate { get; set; }
        public string PaymentPaidDate { get; set; }
        public ICollection<OrderLine> OrderLines { get; set; }
        public decimal OrderTotal = 1;

    }
}
