using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SimplyBooks.Models;
using SimplyBooks.Models.ResultModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimplyBooks.Repository.Queries.Books
{
    public interface IListBooksByYearPublishedQuery
    {
        Task<Result<IList<Book>>> Execute(DateTime year);

    }
    public class ListBooksByYearPublishedQuery : IListBooksByYearPublishedQuery
    {
        private readonly SimplyBooksContext _context;
        private readonly ILogger<ListBooksByYearPublishedQuery> _logger;

        public ListBooksByYearPublishedQuery(SimplyBooksContext context,
            ILogger<ListBooksByYearPublishedQuery> logger)
        {
            _context = context;
            _logger = logger;
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
                            .Where(b => b.YearPublished.Year == year.Year)
                            .ToListAsync();
            }
            catch (Exception ex)
            {
                var message = $"Exception thrown ListByYearPublished:\n Message: {ex.Message}.\n Stacktrace: {ex.StackTrace}";
                result.AddError(message);
                _logger.LogError(message);
            }

            return result;
        }
    }
}
