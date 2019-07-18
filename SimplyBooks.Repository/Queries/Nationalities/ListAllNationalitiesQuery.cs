using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SimplyBooks.Models;
using SimplyBooks.Models.ResultModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimplyBooks.Repository.Queries.Nationalities
{
    public interface IListAllNationalitiesQuery
    {
        Task<Result<IList<Nationality>>> Execute();
    }

    public class ListAllNationalitiesQuery : IListAllNationalitiesQuery
    {
        private readonly SimplyBooksContext _context;
        private readonly ILogger<ListAllNationalitiesQuery> _logger;

        public ListAllNationalitiesQuery(SimplyBooksContext context,
            ILogger<ListAllNationalitiesQuery> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Result<IList<Nationality>>> Execute()
        {
            Result<IList<Nationality>> result = new Result<IList<Nationality>>();

            try
            {
                result.Value = await _context.Nationality
                            .ToListAsync();
            }
            catch (Exception ex)
            {
                var message = $"Exception thrown ListAllNationalitiess:\n Message: {ex.Message}.\n Stacktrace: {ex.StackTrace}";
                result.AddError(message);
                _logger.LogError(message);
            }

            return result;
        }
    }
}
