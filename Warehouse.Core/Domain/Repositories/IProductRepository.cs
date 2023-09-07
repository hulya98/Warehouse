using Warehouse.Core.Domain.Entities;

namespace Warehouse.Core.Domain.Repositories
{
    public interface IProductRepository
    {
        void Add(Product product);
        void Update(Product product);
        void Delete(int id);
        Product Get(int id);
        List<Product> GetAll();
    }
}
