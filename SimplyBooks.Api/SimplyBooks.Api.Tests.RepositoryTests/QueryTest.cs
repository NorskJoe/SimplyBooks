using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using SimplyBooks.Domain;
using System;

namespace SimplyBooks.Api.Tests.RepositoryTests
{
    public class QueryTest<T> : IDisposable
    {
        public SqliteConnection Connection { get; set; }
        public DbContextOptions<SimplyBooksContext> Options { get; set; }

        public QueryTest()
        {
            Connection = new SqliteConnection("DataSource=:memory:");
            Connection.Open();

            Options = new DbContextOptionsBuilder<SimplyBooksContext>()
                    .UseSqlite(Connection)
                    .Options;

            using (var context = new SimplyBooksContext(Options))
            {
                EnsureCreated(context);
            }
        }

        public T CreateQuery(SimplyBooksContext context)
        {
            return (T)Activator.CreateInstance(typeof(T),
               new object[] { new SimplyBooksContext(Options), null });
        }

        public void Dispose() => Connection.Close();

        private static void EnsureCreated(SimplyBooksContext context)
        {
            if (context.Database.EnsureCreated())
            {
                using var viewCommand = context.Database.GetDbConnection().CreateCommand();
                viewCommand.CommandText = @"
                    CREATE VIEW AllResources AS
                    SELECT Name
                    FROM Author;";
                viewCommand.ExecuteNonQuery();
            }
        }
    }

    
}
