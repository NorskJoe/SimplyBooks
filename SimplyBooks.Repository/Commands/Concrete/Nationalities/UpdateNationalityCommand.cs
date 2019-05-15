using SimplyBooks.Models;
using SimplyBooks.Repository.Commands.Interfaces.Nationalities;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SimplyBooks.Repository.Commands.Concrete.Nationalities
{
    class UpdateNationalityCommand : IUpdateNationalityCommand
    {
        public Task<HttpResponseMessage> UpdateNationality(Nationality nationality)
        {
            throw new NotImplementedException();
        }
    }
}
