using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SimplyBooks.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SimplyBooks.Domain.Extensions;
using SimplyBooks.Domain.QueryModels;

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
                var id = _logger.LogErrorWithEventId(ex);
                var message = $"An unhandled exception occured.  An error has been logged with id: {id}";
                result.AddError(message);
            }

            return result;
        }
    }
}
