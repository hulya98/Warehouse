namespace Warehouse.Core.Domain.Repositories
{
    public interface IUnitOfWork
    {
        public ICustomerRepository CustomerRepository { get; }
        public IProductRepository ProductRepository { get; }
        bool IsOnline();
    }
}
