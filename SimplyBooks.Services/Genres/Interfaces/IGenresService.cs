using SimplyBooks.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace SimplyBooks.Services.Genres.Interfaces
{
    public interface IGenresService
    {
        Task<HttpResponseMessage> UpdateGenreAsync(Genre genre);
        Task<HttpResponseMessage> AddGenreAsync(Genre genre);
    }
}
