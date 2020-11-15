using Microsoft.EntityFrameworkCore;

namespace SimplyBooks.Domain
{
    public class SimplyBooksContext : DbContext
    {
        public SimplyBooksContext(DbContextOptions<SimplyBooksContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Nationality> Nationalilties { get; set; }
    }
}
