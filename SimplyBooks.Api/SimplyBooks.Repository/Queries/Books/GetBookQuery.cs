using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SimplyBooks.Models;
using SimplyBooks.Models.ResultModels;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SimplyBooks.Repository.Queries.Books
{
    public interface IGetBookQuery
    {
        Task<Result<Book>> Execute(int id);
    }

    public class GetBookQuery : IGetBookQuery
    {
        private readonly SimplyBooksContext _context;
        private readonly ILogger<GetBookQuery> _logger;

        public GetBookQuery(SimplyBooksContext context,
            ILogger<GetBookQuery> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Result<Book>> Execute(int id)
        {
            Result<Book> result = new Result<Book>();

            try
            {
                result.Value = await _context.Book
                            .Include(b => b.Author)
                                .ThenInclude(a => a.Nationality)
                            .Include(b => b.Genre)
                            .Where(b => b.BookId == id)
                            .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                var message = $"Exception thrown GetBook:\n Message: {ex.Message}.\n Stacktrace: {ex.StackTrace}";
                result.AddError(message);
                _logger.LogError(message);
            }

            return result;
        }
    }
}
