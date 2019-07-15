using Microsoft.EntityFrameworkCore;
using SimplyBooks.Models;
using SimplyBooks.Models.ResultModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimplyBooks.Repository.Queries.Books
{
    public interface IListBooksByGenreQuery
    {
        Task<Result<IList<Book>>> Execute(int id);
    }

    public class ListBooksByGenreQuery : IListBooksByGenreQuery
    {
        private readonly SimplyBooksContext _context;

        public ListBooksByGenreQuery(SimplyBooksContext context)
        {
            _context = context;
        }


        public async Task<Result<IList<Book>>> Execute(int id)
        {
            Result<IList<Book>> result = new Result<IList<Book>>();

            try
            {
                result.Value = await _context.Book
                            .Include(b => b.Author)
                                .ThenInclude(a => a.Nationality)
                            .Include(b => b.Genre)
                            .Where(b => b.Genre.GenreId == id)
                            .ToListAsync();
            }
            catch (Exception ex)
            {
                result.AddError($"Exception thrown ListByGenre:\n Message: {ex.Message}.\n Stacktrace: {ex.StackTrace}");
            }

            return result;
        }
    }
}
