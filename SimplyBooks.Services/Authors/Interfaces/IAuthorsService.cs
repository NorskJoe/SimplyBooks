using SimplyBooks.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace SimplyBooks.Services.Authors.Interfaces
{
    public interface IAuthorsService
    {
        Task<HttpResponseMessage> UpdateAuthorAsync(Author author);
        Task<HttpResponseMessage> AddAuthorAsync(Author author);
    }
}
