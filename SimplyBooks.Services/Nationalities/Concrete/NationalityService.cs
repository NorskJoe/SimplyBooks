using SimplyBooks.Models;
using SimplyBooks.Models.Exceptions;
using SimplyBooks.Repository.Commands.Interfaces.Nationalities;
using SimplyBooks.Services.Nationalities.Interfaces;
using System.Net.Http;
using System.Threading.Tasks;

namespace SimplyBooks.Services.Nationalities.Concrete
{
    class NationalityService : INationalityService
    {
        private readonly IAddNationalityCommand _addNationalityCommand;
        private readonly IUpdateNationalityCommand _updateNationalityCommand;

        public NationalityService(IAddNationalityCommand addNationalityCommand,
            IUpdateNationalityCommand updateNationalityCommand)
        {
            _addNationalityCommand = addNationalityCommand;
            _updateNationalityCommand = updateNationalityCommand;
        }

        public async Task<HttpResponseMessage> AddNationalityAsync(Nationality nationality)
        {
            var response = await _addNationalityCommand.AddNationality(nationality);

            if (response.IsSuccessStatusCode)
            {
                return response;
            }
            else
            {
                throw new EntityAlreadyExistsException(nationality.Name);
            }
            
        }

        public async Task<HttpResponseMessage> UpdateNationalityAsync(Nationality nationality)
        {
            return await _updateNationalityCommand.UpdateNationality(nationality);
        }
    }
}
