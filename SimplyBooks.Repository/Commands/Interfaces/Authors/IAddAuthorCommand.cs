using SimplyBooks.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace SimplyBooks.Repository.Commands.Interfaces.Authors
{
    public interface IAddAuthorCommand
    {
        Task<HttpResponseMessage> AddAuthor(Author author);
    }
}
