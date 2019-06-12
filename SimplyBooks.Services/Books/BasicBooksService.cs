using SimplyBooks.Models;
using SimplyBooks.Models.Exceptions;
using SimplyBooks.Repository.Commands.Books;
using SimplyBooks.Repository.Queries.Books;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace SimplyBooks.Services.Books
{
    public interface IBasicBooksService
    {
        Task<Book> AddBookAsync(Book book);
        Task<HttpResponseMessage> DeleteBookAsync(int bookId);
        Task<HttpResponseMessage> UpdateBookAsync(Book book);
        Task<IList<Book>> ListAllBooksAsync();
        Task<Book> GetBookAsync(int bookId);
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

        public async Task<IList<Book>> ListAllBooksAsync()
        {
            var response = await _listAllBooksQuery.Execute();

            if (response.Count == 0)
            {
                throw new EntityNotFoundException();
            }
            else
            {
                return response;
            }
        }

        public async Task<Book> GetBookAsync(int bookId)
        {
            var response = await _getBookQuery.Execute(bookId);

            if (response == null)
            {
                throw new EntityNotFoundException();
            }
            else
            {
                return response;
            }
        }

        public async Task<Book> AddBookAsync(Book book)
        {
            var newBook = await _addBookCommand.Execute(book);

            if (newBook != null)
            {
                return newBook;
            }
            else
            {
                throw new EntityAlreadyExistsException(book.Title);
            }
        }

        public async Task<HttpResponseMessage> UpdateBookAsync(Book book)
        {
            var response = await _updateBookCommand.Execute(book);

            if (response.IsSuccessStatusCode)
            {
                return response;
            }
            else
            {
                throw new EntityNotFoundException(book.Title);
            }
        }

        public async Task<HttpResponseMessage> DeleteBookAsync(int bookId)
        {
            var response = await _deleteBookCommand.Execute(bookId);

            if (response.IsSuccessStatusCode)
            {
                return response;
            }
            else
            {
                throw new EntityNotFoundException();
            }
        }
    }
}
