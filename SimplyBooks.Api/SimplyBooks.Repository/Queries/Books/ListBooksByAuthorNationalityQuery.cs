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
    public interface IListBooksByAuthorNationalityQuery
    {
        Task<Result<IList<Book>>> Execute(int id);
    }

    public class ListBooksByAuthorNationalityQuery : IListBooksByAuthorNationalityQuery
    {
        private readonly SimplyBooksContext _context;
        private readonly ILogger<ListBooksByAuthorNationalityQuery> _logger;

        public ListBooksByAuthorNationalityQuery(SimplyBooksContext context,
            ILogger<ListBooksByAuthorNationalityQuery> logger)
        {
            _context = context;
            _logger = logger;
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
                            .Where(b => b.Author.Nationality.NationalityId == id)
                            .ToListAsync();
            }
            catch (Exception ex)
            {
                var message = $"Exception thrown ListByNationality:\n Message: {ex.Message}.\n Stacktrace: {ex.StackTrace}";
                result.AddError(message);
                _logger.LogError(message);
            }

            return result;
        }
    }
}
