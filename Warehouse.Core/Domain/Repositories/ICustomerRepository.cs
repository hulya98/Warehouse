using Warehouse.Core.Domain.Entities;

namespace Warehouse.Core.Domain.Repositories
{
    public interface ICustomerRepository
    {
        void Add(Customer customer);
        void Delete(int CustomerId);
        void Update(Customer customer);
        Customer Get(int id);
        List<Customer> GetAll();

    }
}
