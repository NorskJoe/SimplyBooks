using SimplyBooks.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace SimplyBooks.Services.Books.Interfaces
{
    public interface IBasicBooksService
    {
        Task<HttpResponseMessage> AddBookAsync(Book book);
        Task<HttpResponseMessage> DeleteBookAsync(int bookId);
        Task<HttpResponseMessage> UpdateBookAsync(Book book);
        Task<HttpResponseMessage> ListAllBooksAsync();
        Task<HttpResponseMessage> GetBookAsync(int bookId);
    }
}
