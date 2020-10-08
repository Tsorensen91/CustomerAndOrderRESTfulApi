using J41564_CO6029_Assignment2.api.DatabaseModel;
using J41564_CO6029_Assignment2.api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace J41564_CO6029_Assignment2.api.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly Database _database;


        public CustomerService(Database database)
        {
            _database = database ?? throw new ArgumentNullException(nameof(database));
        }
        
        public IEnumerable<CustomerModel> GetAllCustomers()
        {
            try
            {
                var customerModels = (from customer in _database.Customers
                                      join address in _database.Addresses on customer.Id equals address.CustomerId
                                      select new CustomerModel
                                      {
                                          FullName = $"{customer.Firstname} {customer.Lastname}",
                                          Id = customer.Id,
                                          FullAddress = $"{address.Street}, {address.CityTown}, {address.PostalCode}, {address.Country}"
                                      });


                return customerModels;

            } catch (Exception e)
            {
                if (e.Source != null)
                    Console.WriteLine($"{e.Source}");
                throw;
            }
        }
    }
}
