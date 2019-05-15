using SimplyBooks.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace SimplyBooks.Repository.Commands.Interfaces.Authors
{
    public interface IUpdateAuthorCommand
    {
        Task<HttpResponseMessage> UpdateAuthor(Author author);
    }
}
