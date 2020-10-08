using J41564_CO6029_Assignment2.api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace J41564_CO6029_Assignment2.api.Services
{
    public interface ICustomerService
    {
        IEnumerable<CustomerModel> GetAllCustomers();
    }
}
