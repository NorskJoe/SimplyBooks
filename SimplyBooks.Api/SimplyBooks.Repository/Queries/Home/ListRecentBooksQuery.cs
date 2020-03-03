using Microsoft.Extensions.Logging;
using SimplyBooks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SimplyBooks.Models.Extensions;
using SimplyBooks.Models.QueryModels;

namespace SimplyBooks.Repository.Queries.Home
{
    public interface IListRecentBooksQuery
    {
        Task<Result<IList<RecentBookItem>>> Execute();
    }

    public class ListRecentBooksQuery : IListRecentBooksQuery
    {
        private readonly SimplyBooksContext _context;
        private readonly ILogger<ListRecentBooksQuery> _logger;

        public ListRecentBooksQuery(SimplyBooksContext context,
            ILogger<ListRecentBooksQuery> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Result<IList<RecentBookItem>>> Execute()
        {
            var result = new Result<IList<RecentBookItem>>();

            try
            {
                result.Value = _context.Book
                    .Join(_context.Author,
                        b => b.Author.AuthorId,
                        a => a.AuthorId,
                        (b, a) => new {b, a})
                    .OrderByDescending(x => x.b.DateRead)
                    .Select(x => new RecentBookItem
                    {
                        BookTitle = x.b.Title,
                        Author = x.a.Name,
                        Rating = x.b.Rating,
                        DateRead = x.b.DateRead
                    })
                    .Take(10)
                    .ToList();
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

    public class RecentBookItem
    {
        public string BookTitle { get; set; }
        public string Author { get; set; }
        public double Rating { get; set; }
        public DateTime DateRead { get; set; }
    }
}
