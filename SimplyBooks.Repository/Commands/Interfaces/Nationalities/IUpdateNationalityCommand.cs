using SimplyBooks.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace SimplyBooks.Repository.Commands.Interfaces.Nationalities
{
    public interface IUpdateNationalityCommand
    {
        Task<HttpResponseMessage> UpdateNationality(Nationality nationality);
    }
}
