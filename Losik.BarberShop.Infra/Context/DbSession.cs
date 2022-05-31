using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Losik.BarberShop.Infra.Context
{
    public sealed class DbSession : IDisposable
    {
        private Guid _id;
        public IDbConnection Connection { get; set; }
        public IDbTransaction Transaction { get; set; }

        public DbSession(IConfiguration configuration)
        {
            _id = Guid.NewGuid();
            // TODO: Colocar a connection string
            Connection = new SqlConnection(configuration.GetConnectionString("BarberShopContext"));
            Connection.Open();
        }

        public void Dispose() => Connection?.Dispose();
    }
}