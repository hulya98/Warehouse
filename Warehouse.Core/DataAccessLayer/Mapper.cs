using System;
using System.Collections.Generic;
using System.Data;

namespace Warehouse.Core.DataAccessLayer
{
    public static class Mapper
    {
        public static Domain.Entities.Customer Map(IDataReader reader)
        public static Product MapProduct(IDataReader reader)
        {
            return new Domain.Entities.Customer
            return new Product
            {
                CustomerName = (string)reader["CustomerName"],
                CustomerId = (int)reader["CustomerId"],
                ProductId = (int)reader["ProductId"],
                ProductName = (string)reader["ProductName"],
                Stock = (int)reader["Stock"],
                Price = (decimal)reader["Price"],
            };
        }

    }
}
