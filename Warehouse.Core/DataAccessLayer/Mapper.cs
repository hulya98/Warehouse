using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
