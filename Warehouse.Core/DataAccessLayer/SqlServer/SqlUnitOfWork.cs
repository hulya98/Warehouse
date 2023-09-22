using System.Data.SqlClient;
using Warehouse.Core.Domain.Repositories;

namespace Warehouse.Core.DataAccessLayer.SqlServer
{
    public class SqlUnitOfWork : IUnitOfWork
    {
        private readonly string _connectionString;
        public SqlUnitOfWork(string connectionString)
        {
            _connectionString = connectionString;
        }

        public ICustomerRepository CustomerRepository => new SqlCustomerRepository(_connectionString);

        public IProductRepository ProductRepository => new SqlProductRepository(_connectionString);

        public IUserRepository UserRepository => new SqlUserRepository(_connectionString);  
        public bool IsOnline()
        {
            try
            {
                using SqlConnection sqlConnection = new SqlConnection(_connectionString);
                sqlConnection.Open();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
