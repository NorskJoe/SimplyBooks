using SimplyBooks.Models;
using SimplyBooks.Repository.Commands.Interfaces.Books;
using SimplyBooks.Repository.Queries.Interfaces.Books;
using SimplyBooks.Services.Books.Interfaces;
using SimplyBooks.Services.Genres.Concrete;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace SimplyBooks.Services.Books.Concrete
{
    class BasicBooksService : IBasicBooksService
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

        public async Task<HttpResponseMessage> AddBookAsync(Book book)
        {
            var response = await _addBookCommand.Execute(book);

            if (response.IsSuccessStatusCode)
            {
                return response;
            }
            else
            {
                throw new HttpResponseException(HttpStatusCode.Conflict);
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
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        public async Task<Book> GetBookAsync(int bookId)
        {
            return await _getBookQuery.Execute(bookId);
        }

        public async Task<IList<Book>> ListAllBooksAsync()
        {
            return await _listAllBooksQuery.Execute();
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
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }
    }
}
