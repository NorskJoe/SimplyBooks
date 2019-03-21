using SimplyBooks.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace SimplyBooks.Services.Nationalities.Interfaces
{
    public interface INationalityService
    {
        Task<HttpResponseMessage> UpdateNationalityAsync(Nationality nationality);
        Task<HttpResponseMessage> AddNationalityAsync(Nationality nationality);
    }
}
