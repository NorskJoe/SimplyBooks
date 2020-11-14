using Microsoft.Extensions.Localization;
using SimplyBooks.Domain;
using SimplyBooks.Repository.Commands.Books;
using SimplyBooks.Repository.Queries.Books;
using System.Linq;
using System.Threading.Tasks;
using SimplyBooks.Domain.QueryModels;

namespace SimplyBooks.Services.Books
{
    public interface IBooksService : IService
    {
        Task<Result<PagedResult<BookListItem>>> ListBooksAsync(BookListCriteria criteria);
        Task<Result<BookItem>> GetBookAsync(BookItemCriteria criteria);
        Task<Result> AddBookAsync(Book book);
        Task<Result> UpdateBookAsync(Book book);
        Task<Result> DeleteBookAsync(DeleteBookCriteria criteria);
    }

    public class BooksService : IBooksService
    {
        private readonly IAddBookCommand _addBookCommand;
        private readonly IUpdateBookCommand _updateBookCommand;
        private readonly IDeleteBookCommand _deleteBookCommand;
        private readonly IGetBookQuery _getBookQuery;
        private readonly IListAllBooksQuery _listBooksQuery;
        private readonly IStringLocalizer<BooksService> _localiser;

        public BooksService(IAddBookCommand addBookCommand,
            IUpdateBookCommand updateBookCommand,
            IDeleteBookCommand deleteBookCommand,
            IGetBookQuery getBookQuery,
            IListAllBooksQuery listBooksQuery,
            IStringLocalizer<BooksService> localiser)
        {
            _addBookCommand = addBookCommand;
            _updateBookCommand = updateBookCommand;
            _deleteBookCommand = deleteBookCommand;
            _getBookQuery = getBookQuery;
            _listBooksQuery = listBooksQuery;
            _localiser = localiser;
        }

        public async Task<Result<PagedResult<BookListItem>>> ListBooksAsync(BookListCriteria criteria)
        {
            var result = new Result<PagedResult<BookListItem>>();

            var queryResult = await _listBooksQuery.Execute(criteria);

            if (!queryResult.Any())
            {
                result.Warnings.Add(_localiser["NoBooksFound"]);
            }
            else
            {
                var rowItems = queryResult
                    .Skip(criteria.FirstRecord)
                    .Take(criteria.PageSize)
                    .ToList();

                result.Value = new PagedResult<BookListItem>
                {
                    Items = rowItems,
                    PageIndex = criteria.PageIndex,
                    Total = queryResult.Count
                };
            }

            return result;
        }

        public async Task<Result<BookItem>> GetBookAsync(BookItemCriteria criteria)
        {
            var result = new Result<BookItem>();
            result.Value = await _getBookQuery.Execute(criteria);
            return result;
        }

        public async Task<Result> AddBookAsync(Book book)
        {
            return await _addBookCommand.Execute(book);
        }

        public async Task<Result> UpdateBookAsync(Book book)
        {
            return await _updateBookCommand.Execute(book);
        }

        public async Task<Result> DeleteBookAsync(DeleteBookCriteria criteria)
        {
            return await _deleteBookCommand.Execute(criteria);
        }
    }
}
