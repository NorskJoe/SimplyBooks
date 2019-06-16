using SimplyBooks.Models;
using SimplyBooks.Models.ResultModels;
using SimplyBooks.Repository.Commands.Books;
using SimplyBooks.Repository.Queries.Books;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimplyBooks.Services.Books
{
    public interface IBasicBooksService
    {
        Task<Result<List<Book>>> ListAllBooksAsync();
        Task<Result<Book>> GetBookAsync(int bookId);
        Task<Result> AddBookAsync(Book book);
        Task<Result> UpdateBookAsync(Book book);
        Task<Result> DeleteBookAsync(int bookId);
    }

    public class BasicBooksService : IBasicBooksService
    {
        private readonly IAddBookCommand _addBookCommand;
        private readonly IUpdateBookCommand _updateBookCommand;
        private readonly IDeleteBookCommand _deleteBookCommand;
        private readonly IGetBookQuery _getBookQuery;
        private readonly IListAllBooksQuery _listAllBooksQuery;

        public BasicBooksService(IAddBookCommand addBookCommand,
            IUpdateBookCommand updateBookCommand,
            IDeleteBookCommand deleteBookCommand,
            IGetBookQuery getBookQuery,
            IListAllBooksQuery listAllBooksQuery)
        {
            _addBookCommand = addBookCommand;
            _updateBookCommand = updateBookCommand;
            _deleteBookCommand = deleteBookCommand;
            _getBookQuery = getBookQuery;
            _listAllBooksQuery = listAllBooksQuery;
        }

        public async Task<Result<List<Book>>> ListAllBooksAsync()
        {
            return await _listAllBooksQuery.Execute();
        }

        public async Task<Result<Book>> GetBookAsync(int bookId)
        {
            return await _getBookQuery.Execute(bookId);
        }

        public async Task<Result> AddBookAsync(Book book)
        {
            return await _addBookCommand.Execute(book);
        }

        public async Task<Result> UpdateBookAsync(Book book)
        {
            return await _updateBookCommand.Execute(book);
        }

        public async Task<Result> DeleteBookAsync(int bookId)
        {
            return await _deleteBookCommand.Execute(bookId);
        }
    }
}
