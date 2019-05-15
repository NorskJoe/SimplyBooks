using System.Net.Http;
using System.Threading.Tasks;

namespace SimplyBooks.Repository.Commands.Interfaces.Books
{
    public interface IDeleteBookCommand
    {
        Task<HttpResponseMessage> Execute(int id);
    }
}
