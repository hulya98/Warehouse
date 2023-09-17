using System;
using System.Data.SqlClient;
using Warehouse.Core.DataAccessLayer.SqlServer;
using Warehouse.Core.Domain.Repositories;
using Warehouse.Settings;

namespace Warehouse.Factories
{
    public static class DbFactory
    {
        public static IUnitOfWork Get(AppSettings settings)
        {
            switch (settings.DbType)
            {
                case Core.Enums.DatabaseType.SqlServer:
                    SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                    builder.InitialCatalog = settings.DbName;
                    builder.DataSource = settings.DbHost;
                    builder.UserID = settings.UserName;
                    builder.Password = settings.Password;
                    builder.IntegratedSecurity = settings.WindowsAuthetication;
                    builder.TrustServerCertificate = true;
                    string connectionString = builder.ToString();
                    return new SqlUnitOfWork(connectionString);
                default:
                    throw new NotSupportedException($"{settings.DbType} not supported");
            }


        }
    }
}
