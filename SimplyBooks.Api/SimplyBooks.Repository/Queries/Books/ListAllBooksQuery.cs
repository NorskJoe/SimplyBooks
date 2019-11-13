using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<ListAllBooksQuery> _logger;

        public ListAllBooksQuery(SimplyBooksContext context,
            ILogger<ListAllBooksQuery> logger)
        {
            _context = context;
            _logger = logger;
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
                var message = $"Exception thrown ListAllBooks:\n Message: {ex.Message}.\n Stacktrace: {ex.StackTrace}";
                result.AddError(message);
                _logger.LogError(message);
            }

            return result;
        }
    }
}
