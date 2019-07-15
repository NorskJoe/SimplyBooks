using Microsoft.EntityFrameworkCore;
using SimplyBooks.Models;
using SimplyBooks.Models.ResultModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimplyBooks.Repository.Queries.Books
{
    public interface IListBooksByYearReadQuery
    {
        Task<Result<IList<Book>>> Execute(DateTime year);
    }

    public class ListBooksByYearReadQuery : IListBooksByYearReadQuery
    {
        private readonly SimplyBooksContext _context;

        public ListBooksByYearReadQuery(SimplyBooksContext context)
        {
            _context = context;
        }

        public async Task<Result<IList<Book>>> Execute(DateTime year)
        {
            Result<IList<Book>> result = new Result<IList<Book>>();

            try
            {
                result.Value = await _context.Book
                            .Include(b => b.Author)
                                .ThenInclude(a => a.Nationality)
                            .Include(b => b.Genre)
                            .Where(b => b.YearRead.Year == year.Year)
                            .ToListAsync();
            }
            catch (Exception ex)
            {
                result.AddError($"Exception thrown ListByYearRead:\n Message: {ex.Message}.\n Stacktrace: {ex.StackTrace}");
            }

            return result;
        }
    }
}
