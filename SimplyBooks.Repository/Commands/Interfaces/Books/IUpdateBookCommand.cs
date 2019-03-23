using SimplyBooks.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace SimplyBooks.Repository.Commands.Interfaces.Books
{
    public interface IUpdateBookCommand
    {
        Task<HttpResponseMessage> Execute(Book book);
    }
}
