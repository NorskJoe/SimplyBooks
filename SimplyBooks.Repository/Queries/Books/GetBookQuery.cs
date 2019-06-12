using Microsoft.EntityFrameworkCore;
using SimplyBooks.Models;
using System;
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
            Book book = null;
            try
            {
                book = await _context.Book
                                .Where(x => x.BookId == id)
                                .FirstOrDefaultAsync();
            }
            catch (Exception)
            {
                // TODO
            }
            return book;
        }
    }
}
