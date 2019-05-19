using SimplyBooks.Models;
using SimplyBooks.Models.Exceptions;
using SimplyBooks.Repository.Commands.Nationalities;
using System.Net.Http;
using System.Threading.Tasks;

namespace SimplyBooks.Services.Nationalities
{
    public interface INationalityService
    {
        Task<HttpResponseMessage> AddNationalityAsync(Nationality nationality);
        Task<HttpResponseMessage> UpdateNationalityAsync(Nationality nationality);
    }

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
            var response = await _updateNationalityCommand.UpdateNationality(nationality);

            if (response.IsSuccessStatusCode)
            {
                return response;
            }
            else
            {
                throw new EntityNotFoundException(nationality.Name);
            }
        }
    }
}
