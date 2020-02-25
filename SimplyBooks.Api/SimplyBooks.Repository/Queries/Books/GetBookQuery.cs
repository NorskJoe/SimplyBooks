using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SimplyBooks.Models;
using SimplyBooks.Models.ResultModels;
using System;
using System.Linq;
using System.Threading.Tasks;
using SimplyBooks.Models.Extensions;

namespace SimplyBooks.Repository.Queries.Books
{
    public interface IGetBookQuery
    {
        Task<Result<BookItem>> Execute(int id);
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

        public async Task<Result<BookItem>> Execute(int id)
        {
            var result = new Result<BookItem>();

            try
            {
                result.Value = await _context.Book
                    .Join(_context.Author,
                        b => b.Author.AuthorId,
                        a => a.AuthorId,
                        (b, a) => new { b, a })
                    .Join(_context.Nationality,
                        x => x.a.Nationality.NationalityId,
                        n => n.NationalityId,
                        (x, n) => new { x.b, x.a, n })
                    .Where(x => x.b.BookId == id)
                    .Select(x => new BookItem
                    {
                        Title = x.b.Title,
                        Author = x.a.Name,
                        AuthorNationality = x.n.Name,
                        Rating = x.b.Rating,
                        DateRead = x.b.DateRead.ToShortDateString(),
                        YearPublished = x.b.YearPublished.Year.ToString()
                    })
                    .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                var eventId = _logger.LogErrorWithEventId(ex);
                var message = $"An unhandled exception occured.  An error has been logged with id: {eventId}";
                result.AddError(message);
            }

            return result;
        }
    }

    public class BookItem
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string AuthorNationality { get; set; }
        public double Rating { get; set; }
        public string DateRead { get; set; }
        public string YearPublished { get; set; }
    }
}
