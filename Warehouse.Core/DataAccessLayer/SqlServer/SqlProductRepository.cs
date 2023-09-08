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
            const string query = "Insert into Products values(@ProductName,@Price,@Stock)";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("ProductName", product.ProductName);
            cmd.Parameters.AddWithValue("Price", product.Price);
            cmd.Parameters.AddWithValue("Stock", product.Stock);
            cmd.ExecuteNonQuery();

        }

        public void Delete(int productId)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            const string query = "delete from Products where ProductId = @ProductId";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("ProductId", productId);
            cmd.ExecuteNonQuery();
        }
        public void Update(Product product)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            const string query = "update Products set ProductName = @ProductName , Price = @Price, Stock = @Stock where ProductId = @ProductId";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("CustomerId", product.ProductId);
            cmd.Parameters.AddWithValue("ProductName", product.ProductName);
            cmd.Parameters.AddWithValue("Price", product.Price);
            cmd.Parameters.AddWithValue("Stock", product.Stock);
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
