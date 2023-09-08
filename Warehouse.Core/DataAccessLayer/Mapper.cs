using System;
using System.Collections.Generic;
using System.Data;
using Warehouse.Core.Domain.Entities;

namespace Warehouse.Core.DataAccessLayer
{
    public static class Mapper
    {
        public static Domain.Entities.Customer Map(IDataReader reader)
        {
            return new Domain.Entities.Customer
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

    }
}
