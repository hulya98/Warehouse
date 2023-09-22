namespace Warehouse.Core.Domain.Repositories
{
    public interface IUnitOfWork
    {
        public ICustomerRepository CustomerRepository { get; }
        public IProductRepository ProductRepository { get; }

        public IUserRepository UserRepository     { get; }    
        bool IsOnline();
    }
}
