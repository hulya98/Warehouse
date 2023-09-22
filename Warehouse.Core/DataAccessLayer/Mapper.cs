using System;
using System.Collections.Generic;
using System.Data;
using Warehouse.Core.Domain.Entities;
using Warehouse.Core.Domain.Repositories;

namespace Warehouse.Core.DataAccessLayer
{
    public static class Mapper
    {
        public static Customer MapCustomer(IDataReader reader)
        {
            return new Customer
            {
                CustomerName = (string)reader["CustomerName"],
                CustomerId = (int)reader["CustomerId"],
            };

        }
        public static Product MapProduct(IDataReader reader)
        {
            return new Product
            {
              
                ProductId = (int)reader["ProductId"],
                ProductName = (string)reader["ProductName"],
                Stock = (int)reader["Stock"],
                Price = (decimal)reader["Price"],
            };
        }

        public static User MapUser(IDataReader reader)
        {
            return new User
            {
                Id = (int)reader["id"],
                UserName = (string)reader["UserName"],
                Email = (string)reader["Email"],
                PasswordHash = (string)reader["PasswordHash"],
            };
        }

    }
}
