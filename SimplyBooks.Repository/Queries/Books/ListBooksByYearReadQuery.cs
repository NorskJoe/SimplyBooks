using Microsoft.EntityFrameworkCore;
using SimplyBooks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimplyBooks.Repository.Queries.Books
{
    public interface IListBooksByYearReadQuery
    {
        Task<IList<Book>> Execute(DateTime year);
    }

    public class ListBooksByYearReadQuery : IListBooksByYearReadQuery
    {
        private readonly SimplyBooksContext _context;

        public ListBooksByYearReadQuery(SimplyBooksContext context)
        {
            _context = context;
        }

        public async Task<IList<Book>> Execute(DateTime year)
        {
            return await _context.Book
                            .Include(b => b.Author)
                                .ThenInclude(a => a.Nationality)
                            .Include(b => b.Genre)
                            .Where(b => b.YearRead.Year == year.Year)
                            .ToListAsync();
        }
    }
}
