using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SimplyBooks.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SimplyBooks.Domain.Extensions;

namespace SimplyBooks.Repository.Queries.Genres
{
    public interface IListAllGenresQuery
    {
        Task<IList<Genre>> Execute();
    }

    public class ListAllGenresQuery : IListAllGenresQuery
    {
        private readonly SimplyBooksContext _context;
        private readonly ILogger<ListAllGenresQuery> _logger;

        public ListAllGenresQuery(SimplyBooksContext context,
            ILogger<ListAllGenresQuery> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IList<Genre>> Execute()
        {
            List<Genre> result = new List<Genre>();

            try
            {
                result = await _context.Genres
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
