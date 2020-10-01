using SimplyBooks.Domain;
using SimplyBooks.Repository.Commands.Nationalities;
using SimplyBooks.Repository.Queries.Nationalities;
using System.Collections.Generic;
using System.Threading.Tasks;
using SimplyBooks.Domain.QueryModels;
using Microsoft.EntityFrameworkCore.Internal;
using System.Linq;
using Microsoft.Extensions.Localization;

namespace SimplyBooks.Services.Nationalities
{
    public interface INationalityService : IService
    {
        Task<Result> AddNationalityAsync(Nationality nationality);
        Task<Result> UpdateNationalityAsync(Nationality nationality);
        Task<Result<NationalitySelectList>> SelectList(); 
    }

    public class NationalitiesService : INationalityService
    {
        private readonly IAddNationalityCommand _addNationalityCommand;
        private readonly IUpdateNationalityCommand _updateNationalityCommand;
        private readonly INationalitySelectListQuery _nationalitySelectListQuery;
        private readonly IStringLocalizer<NationalitiesService> _localizer;

        public NationalitiesService(IAddNationalityCommand addNationalityCommand,
            IUpdateNationalityCommand updateNationalityCommand,
            INationalitySelectListQuery nationalitySelectListQuery,
            IStringLocalizer<NationalitiesService> localizer)
        {
            _addNationalityCommand = addNationalityCommand;
            _updateNationalityCommand = updateNationalityCommand;
            _nationalitySelectListQuery = nationalitySelectListQuery;
            _localizer = localizer;
        }

        public async Task<Result<NationalitySelectList>> SelectList()
        {
            var result = new Result<NationalitySelectList>();

            var queryResult = await _nationalitySelectListQuery.Execute();

            if (!queryResult.Any())
            {
                result.AddWarning(_localizer["NoNationalitiesSelectList"]);
            }
            else
            {
                result.Value = new NationalitySelectList
                {
                    Items = queryResult
                };
            }

            return result;
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

    public class NationalitySelectList
    {
        public IList<NationalitySelectListItem> Items { get; set; }
    }
}
