using Microsoft.EntityFrameworkCore;

namespace SimplyBooks.Domain
{
    public class SimplyBooksContext : DbContext
    {
        public SimplyBooksContext(DbContextOptions<SimplyBooksContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Book { get; set; }
        public DbSet<Author> Author { get; set; }
        public DbSet<Genre> Genre { get; set; }
        public DbSet<Nationality> Nationality { get; set; }
    }
}
