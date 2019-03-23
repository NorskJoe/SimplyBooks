using SimplyBooks.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace SimplyBooks.Repository.Commands.Interfaces.Nationalities
{
    public interface IAddNationalityCommand
    {
        Task<HttpResponseMessage> AddNationality(Nationality nationality);
    }
}
