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
        Task<List<Nationality>> Execute();
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

        public async Task<List<Nationality>> Execute()
        {
            List<Nationality> result = new List<Nationality>();

            try
            {
                result = await _context.Nationalilties
                            .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogErrorWithEventId(ex);
            }

            return result;
        }
    }
}
