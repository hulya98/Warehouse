using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.Core.Domain.Entities;
using Warehouse.Core.Domain.Repositories;

namespace Warehouse.Core.DataAccessLayer.SqlServer
{
    public class SqlUserRepository : IUserRepository
    {
        private readonly string _connectionString;

        public SqlUserRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Add(User user) 
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            const string query = "Insert into Users values(@UserName,@Email,@PasswordHash)";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("UserName", user.UserName);
            cmd.Parameters.AddWithValue("Email", user.Email);
            cmd.Parameters.AddWithValue("PasswordHash", user.PasswordHash);
            cmd.ExecuteNonQuery();
        }

        public User Get(string  userName)
        { 
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            const string query = "select * from Users where id = @id";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("username", userName);
            SqlDataReader reader = cmd.ExecuteReader();
            if(reader.Read()) 
            {
                return Mapper.MapUser(reader);
            }
            return null;

        }
    }
}
