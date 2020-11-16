using Microsoft.Extensions.Logging;
using SimplyBooks.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SimplyBooks.Domain.Extensions;
using Microsoft.EntityFrameworkCore;

namespace SimplyBooks.Repository.Queries.Home
{
    public interface IListRecentBooksQuery : IQuery<IList<RecentBookItem>>
    {
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

        public async Task<IList<RecentBookItem>> Execute()
        {
            var result = new List<RecentBookItem>();

            try
            {
                result = await _context.Books
                    .Join(_context.Authors,
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
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogErrorWithEventId(ex);
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
