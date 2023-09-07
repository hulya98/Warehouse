using System.Data.SqlClient;
using Warehouse.Core.Domain.Entities;
using Warehouse.Core.Domain.Repositories;

namespace Warehouse.Core.DataAccessLayer.SqlServer
{
    public class SqlProductRepository : IProductRepository
    {
        private readonly string _connectionString;
        public SqlProductRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public void Add(Product product)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            const string query = "INSERT INTO dbo.Products(@productName,@price,@stock)";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@productName", product.ProductName);
            cmd.Parameters.AddWithValue("@price", product.Price);
            cmd.Parameters.AddWithValue("@stock", product.Stock);
            cmd.ExecuteNonQuery();

        }

        public void Delete(int id)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            const string query = "Delete from dbo.Products where ProductId = @id";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }
        public void Update(Product product)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            const string query = "update dbo.Products set ProductName = @productName,Price = @price,Stock = @stock where ProductId = @productId";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@productName", product.ProductName);
            cmd.Parameters.AddWithValue("@price", product.Price);
            cmd.Parameters.AddWithValue("@stock", product.Stock);
            cmd.Parameters.AddWithValue("@id", product.ProductId);

            cmd.ExecuteNonQuery();
        }

        public Product Get(int id)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            const string query = "select * from dbo.Products where ProductId = @id";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
                return Mapper.MapProduct(reader);
            return null;
        }

        public List<Product> GetAll()
        {
            List<Product> products = new List<Product>();
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            const string query = "select * from dbo.Products";

            SqlCommand cmd = new SqlCommand(query, connection);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Product product = Mapper.MapProduct(reader);
                products.Add(product);
            }
            return products;

        }

    }

}
