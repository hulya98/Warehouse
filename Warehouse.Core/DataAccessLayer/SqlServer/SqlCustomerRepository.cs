using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Warehouse.Core.Domain.Entities;
using Warehouse.Core.Domain.Repositories;

namespace Warehouse.Core.DataAccessLayer.SqlServer
{
    internal class SqlCustomerRepository : ICustomerRepository
    {
        private readonly string _connectionString;

        public SqlCustomerRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Add(Customer customer)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            const string query = "Insert into Customers values(@CustomerName)";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("CustomerName",customer.CustomerName);
            cmd.ExecuteNonQuery();
            
        }

        public void Delete(int customerId )
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            const string query = "delete from Customers where CustomerId = @CustomerId";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("CustomerId",customerId);
            cmd.ExecuteNonQuery();
        }
        public void Update(Customer customer)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            const string query = "update Customers set CustomerName = @CustomerName where CustomerId = @CustomerId";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("CustomerId", customer.CustomerId);
            cmd.ExecuteNonQuery();
        }

        public Customer Get(int id)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            const string query = "select * from Customers where CustomersId = @CustomersId";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("CustomerId", id);
            SqlDataReader reader = cmd.ExecuteReader();
            if(reader.Read()) 
            {
                return Mapper.MapCustomer(reader);
            }
            return null;
        }

        public List<Customer> GetAll()
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            const string query = "select * from Customers ";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            List<Customer> result = new List<Customer>();
            while (reader.Read())
            {
                Customer customer = Mapper.MapCustomer(reader);
                result.Add(customer);
                
            }
            return result;
        }

       
    }

}
