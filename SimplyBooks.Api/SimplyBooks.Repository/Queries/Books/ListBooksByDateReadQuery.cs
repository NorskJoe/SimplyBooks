using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SimplyBooks.Models;
using SimplyBooks.Models.ResultModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SimplyBooks.Models.Extensions;

namespace SimplyBooks.Repository.Queries.Books
{
    public interface IListBooksByDateReadQuery
    {
        Task<Result<IList<Book>>> Execute(DateTime year);
    }

    public class ListBooksByDateReadQuery : IListBooksByDateReadQuery
    {
        private readonly SimplyBooksContext _context;
        private readonly ILogger<ListBooksByDateReadQuery> _logger;

        public ListBooksByDateReadQuery(SimplyBooksContext context,
            ILogger<ListBooksByDateReadQuery> logger)
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
                            .Where(b => b.DateRead.Year == year.Year)
                            .OrderByDescending(b => b.DateRead)
                            .ToListAsync();
            }
            catch (Exception ex)
            {
                var id = _logger.LogErrorWithEventId(ex);
                var message = $"An unhandled exception occured.  An error has been logged with id: {id}";
                result.AddError(message);
            }

            return result;
        }
    }
}
