using SimplyBooks.Models;
using SimplyBooks.Models.Exceptions;
using SimplyBooks.Models.ResultModels;
using SimplyBooks.Repository.Commands.Nationalities;
using SimplyBooks.Repository.Queries.Nationalities;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace SimplyBooks.Services.Nationalities
{
    public interface INationalityService
    {
        Task<Result<IList<Nationality>>> ListAllNationalitiesAsync();
        Task<Result> AddNationalityAsync(Nationality nationality);
        Task<Result> UpdateNationalityAsync(Nationality nationality);
    }

    public class NationalityService : INationalityService
    {
        private readonly IAddNationalityCommand _addNationalityCommand;
        private readonly IUpdateNationalityCommand _updateNationalityCommand;
        private readonly IListAllNationalitiesQuery _listAllNationalitiesQuery;

        public NationalityService(IAddNationalityCommand addNationalityCommand,
            IUpdateNationalityCommand updateNationalityCommand,
            IListAllNationalitiesQuery listAllNationalitiesQuery)
        {
            _addNationalityCommand = addNationalityCommand;
            _updateNationalityCommand = updateNationalityCommand;
            _listAllNationalitiesQuery = listAllNationalitiesQuery;
        }

        public async Task<Result<IList<Nationality>>> ListAllNationalitiesAsync()
        {
            return await _listAllNationalitiesQuery.Execute();
        }

        public async Task<Result> AddNationalityAsync(Nationality nationality)
        {
            return await _addNationalityCommand.Execute(nationality);
            
        }

        public async Task<Result> UpdateNationalityAsync(Nationality nationality)
        {
            return await _updateNationalityCommand.Execute(nationality);
        }
    }
}
