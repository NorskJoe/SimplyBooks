using Microsoft.Extensions.Logging;
using SimplyBooks.Models;
using SimplyBooks.Models.ResultModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplyBooks.Repository.Queries.Home
{
    public interface IListRecentBooksQuery
    {
        Result<IList<RecentBookItem>> Execute();
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

        public Result<IList<RecentBookItem>> Execute()
        {
            var result = new Result<IList<RecentBookItem>>();

            try
            {
                var recent = from b in _context.Book
                           join a in _context.Author on b.Author.AuthorId equals a.AuthorId
                           where b.YearRead.Month > DateTime.Now.AddMonths(-6).Month
                           select new RecentBookItem
                           {
                               BookTitle = b.Title,
                               Author = a.Name,
                               Rating = b.Rating
                           };

                result.Value = recent.ToList();
            }
            catch (Exception ex)
            {
                var message = $"Exception thrown ListRecentBooks:\n Message: {ex.Message}.\n Stacktrace: {ex.StackTrace}";
                result.AddError(message);
                _logger.LogError(message);
            }


            return result;
        }
    }

    public class RecentBookItem
    {
        public string BookTitle { get; set; }
        public string Author { get; set; }
        public double Rating { get; set; }
    }
}
