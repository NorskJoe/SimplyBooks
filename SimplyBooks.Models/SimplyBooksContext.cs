using Microsoft.EntityFrameworkCore;

namespace SimplyBooks.Models
{
    public class SimplyBooksContext : DbContext
    {
        public DbSet<Book> Book { get; set; }
        public DbSet<Author> Author { get; set; }
        public DbSet<Genre> Genre { get; set; }
        public DbSet<Nationality> Nationality { get; set; }

        public SimplyBooksContext(DbContextOptions<SimplyBooksContext> options)
            : base(options)
        {

        }
    }
}
