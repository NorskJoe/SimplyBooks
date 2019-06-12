using Microsoft.EntityFrameworkCore;
using SimplyBooks.Models;
using System.Linq;
using System.Threading.Tasks;

namespace SimplyBooks.Repository.Queries.Books
{
    public interface IGetBookQuery
    {
        Task<Book> Execute(int id);
    }

    public class GetBookQuery : IGetBookQuery
    {
        private readonly SimplyBooksContext _context;

        public GetBookQuery(SimplyBooksContext context)
        {
            _context = context;
        }

        public async Task<Book> Execute(int id)
        {
            return await _context.Book
                            .Include(b => b.Author)
                                .ThenInclude(a => a.Nationality)
                            .Include(b => b.Genre)
                            .Where(b => b.BookId == id)
                            .FirstOrDefaultAsync();
        }
    }
}
