using Microsoft.EntityFrameworkCore;
using SimplyBooks.Models;
using SimplyBooks.Models.ResultModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimplyBooks.Repository.Queries.Books
{
    public interface IListAllBooksQuery
    {
        Task<Result<IList<Book>>> Execute();
    }

    public class ListAllBooksQuery : IListAllBooksQuery
    {
        private readonly SimplyBooksContext _context;

        public ListAllBooksQuery(SimplyBooksContext context)
        {
            _context = context;
        }

        public async Task<Result<IList<Book>>> Execute()
        {
            Result<IList<Book>> result = new Result<IList<Book>>();

            try
            {
                result.Value = await _context.Book
                            .Include(b => b.Author)
                                .ThenInclude(a => a.Nationality)
                            .Include(b => b.Genre)
                            .ToListAsync();
            }
            catch (Exception ex)
            {
                result.AddError($"Exception thrown ListAllBooks:\n Message: {ex.Message}.\n Stacktrace: {ex.StackTrace}");
            }

            return result;
        }
    }
}
