using SimplyBooks.Models.ResultModels;
using SimplyBooks.Repository.Queries.Home;
using System.Collections.Generic;

namespace SimplyBooks.Services.Home
{
    public interface IHomeService
    {
        Result<RecentBooksList> GetRecentBooks();
    }

    public class HomeService : IHomeService
    {
        private readonly IListRecentBooksQuery _listRecentBooksQuery;

        public HomeService(IListRecentBooksQuery listRecentBooksQuery)
        {
            _listRecentBooksQuery = listRecentBooksQuery;
        }

        public Result<RecentBooksList> GetRecentBooks()
        {
            var result = new Result<RecentBooksList>();

            var queryResult = _listRecentBooksQuery.Execute();

            if (queryResult.IsSuccess)
            {
                result.Value = new RecentBooksList
                {
                    Items = queryResult.Value
                };
            }

            return result;
        }
    }

    public class RecentBooksList
    {
        public IList<RecentBookItem> Items { get; set; }
    }
}
