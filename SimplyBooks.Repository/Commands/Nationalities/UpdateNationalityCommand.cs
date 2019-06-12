using SimplyBooks.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SimplyBooks.Repository.Commands.Nationalities
{
    public interface IUpdateNationalityCommand
    {
        Task<HttpResponseMessage> UpdateNationality(Nationality nationality);
    }

    public class UpdateNationalityCommand : IUpdateNationalityCommand
    {
        public Task<HttpResponseMessage> UpdateNationality(Nationality nationality)
        {
            throw new NotImplementedException();
        }
    }
}
