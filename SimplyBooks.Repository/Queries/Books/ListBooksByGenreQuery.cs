using Microsoft.EntityFrameworkCore;
using SimplyBooks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimplyBooks.Repository.Queries.Books
{
    public interface IListBooksByGenreQuery
    {
        Task<IList<Book>> Execute(int id);
    }

    public class ListBooksByGenreQuery : IListBooksByGenreQuery
    {
        private readonly SimplyBooksContext _context;

        public ListBooksByGenreQuery(SimplyBooksContext context)
        {
            _context = context;
        }


        public async Task<IList<Book>> Execute(int id)
        {
            return await _context.Book
                            .Include(b => b.Author)
                                .ThenInclude(a => a.Nationality)
                            .Include(b => b.Genre)
                            .Where(b => b.Genre.GenreId == id)
                            .ToListAsync();
        }
    }
}
