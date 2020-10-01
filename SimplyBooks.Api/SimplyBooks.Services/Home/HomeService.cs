using SimplyBooks.Repository.Queries.Home;
using System.Collections.Generic;
using System.Threading.Tasks;
using SimplyBooks.Domain.QueryModels;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Localization;
using System.Linq;

namespace SimplyBooks.Services.Home
{
    public interface IHomeService : IService
    {
        Task<Result<RecentBooksList>> GetRecentBooks();
    }

    public class HomeService : IHomeService
    {
        private readonly IListRecentBooksQuery _listRecentBooksQuery;
        private readonly IStringLocalizer<HomeService> _localizer;

        public HomeService(IListRecentBooksQuery listRecentBooksQuery,
            IStringLocalizer<HomeService> localizer)
        {
            _listRecentBooksQuery = listRecentBooksQuery;
            _localizer = localizer;
        }

        public async Task<Result<RecentBooksList>> GetRecentBooks()
        {
            var result = new Result<RecentBooksList>();

            var queryResult = await _listRecentBooksQuery.Execute();

            if (!queryResult.Any())
            {
                result.AddWarning(_localizer["NoRecentBooks"]);
            }
            else
            {
                result.Value = new RecentBooksList
                {
                    Items = queryResult
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
