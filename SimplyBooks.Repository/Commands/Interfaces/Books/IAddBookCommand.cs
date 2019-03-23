using SimplyBooks.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace SimplyBooks.Repository.Commands.Interfaces.Books
{
    public interface IAddBookCommand
    {
        Task<HttpResponseMessage> Execute(Book book);
    }
}
