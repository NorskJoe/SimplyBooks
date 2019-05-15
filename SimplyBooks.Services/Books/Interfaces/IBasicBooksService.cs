using SimplyBooks.Models;
using SimplyBooks.Services.Books.Concrete;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace SimplyBooks.Services.Books.Interfaces
{
    public interface IBasicBooksService
    {
        Task<HttpResponseMessage> AddBookAsync(Book book);
        Task<HttpResponseMessage> DeleteBookAsync(int bookId);
        Task<HttpResponseMessage> UpdateBookAsync(Book book);
        Task<IList<Book>> ListAllBooksAsync();
        Task<Book> GetBookAsync(int bookId);
    }
}
