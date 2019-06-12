using Microsoft.EntityFrameworkCore;
using SimplyBooks.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimplyBooks.Repository.Queries.Books
{
    public interface IListAllBooksQuery
    {
        Task<IList<Book>> Execute();
    }

    public class ListAllBooksQuery : IListAllBooksQuery
    {
        private readonly SimplyBooksContext _context;

        public ListAllBooksQuery(SimplyBooksContext context)
        {
            _context = context;
        }

        public async Task<IList<Book>> Execute()
        {
            return await _context.Book
                            .Include(b => b.Author)
                                .ThenInclude(a => a.Nationality)
                            .Include(b => b.Genre)
                            .ToListAsync();
        }
    }
}
