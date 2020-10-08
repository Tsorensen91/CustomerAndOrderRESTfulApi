using J41564_CO6029_Assignment2.api.Classes;
using J41564_CO6029_Assignment2.api.DatabaseModel;
using J41564_CO6029_Assignment2.api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace J41564_CO6029_Assignment2.api.Services
{
    public class OrderService : IOrderService
    {
        private readonly Database _database;


        public OrderService(Database database)
        {
            _database = database ?? throw new ArgumentNullException(nameof(database));
        }
        
        public IEnumerable<OrderModel> GetAllOrders()
        {
            try
            {

                var basketItemModels = CreateBasketItems();

                var orderModels = (from order in _database.Orders
                                   select new OrderModel
                                   {
                                       OrderId = order.Id,
                                       CustomerId = order.CustomerId,
                                       OrderTotal = 0.0M
                                   }).ToList();

                foreach (OrderModel orderModel in orderModels)
                {
                    foreach (BasketItemModel basketItem in basketItemModels)
                    {
                        if (basketItem.OrderID == orderModel.OrderId)
                        {
                            orderModel.OrderTotal += (basketItem.Quantity * basketItem.Price);
                        }
                        
                    }
                }

                

                return orderModels;

            } catch (Exception e)
            {
                if (e.Source != null)
                    Console.WriteLine($"{e.Source}");
                throw;
            }
        }

        public IEnumerable<BasketItemModel> CreateBasketItems()
        {
            var basketItemModels = (from orderline in _database.Orderlines
                                  join product in _database.Products on orderline.ProductId equals product.Id
                                  select new BasketItemModel
                                  {

                                      OrderLineID = orderline.Id,
                                      OrderID = orderline.OrderId,
                                      ProductID = orderline.ProductId,
                                      Quantity = orderline.Quantity,
                                      Price = product.Price
                                  }).ToList();

            return basketItemModels;


        }

    }
}
