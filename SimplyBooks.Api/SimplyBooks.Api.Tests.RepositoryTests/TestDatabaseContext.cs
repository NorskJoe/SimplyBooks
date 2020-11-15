using Microsoft.EntityFrameworkCore;
using SimplyBooks.Domain;
using System;
using System.Data.Common;
using System.Data.SqlClient;

namespace SimplyBooks.Api.Tests.RepositoryTests
{
    public class TestDatabaseContext : IDisposable
    {
        public TestDatabaseContext Context => new TestDatabaseContext();
        public DbConnection Connection { get; }

        public TestDatabaseContext()
        {
            Connection = new SqlConnection(@"Server=(localdb)\mssqllocaldb;Database=SimpleBooks_Test;ConnectRetryCount=0");

            Connection.Open();
        }

        public void Dispose() => Connection.Dispose();


        public SimplyBooksContext CreateContext(DbTransaction transaction = null)
        {
            var context = new SimplyBooksContext(
                new DbContextOptionsBuilder<SimplyBooksContext>().UseSqlServer(Connection).Options);

            if (transaction != null)
            {
                context.Database.UseTransaction(transaction);
            }

            return context;
        }
    }
}
