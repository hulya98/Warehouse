using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.Core.Domain.Entities;

namespace Warehouse.Core.Domain.Repositories
{
    internal interface ICustomerRepository
    {
        void Add(Customer customer);
        void Delete(int CustomerId);
        void Update(Customer customer);
        Customer Get(int id);
        List<Customer> Get();
        List<Customer> Get();
    }
}
