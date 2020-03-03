using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SimplyBooks.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SimplyBooks.Models.Extensions;
using SimplyBooks.Models.QueryModels;

namespace SimplyBooks.Repository.Queries.Genres
{
    public interface IListAllGenresQuery
    {
        Task<Result<IList<Genre>>> Execute();
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

        public async Task<Result<IList<Genre>>> Execute()
        {
            Result<IList<Genre>> result = new Result<IList<Genre>>();

            try
            {
                result.Value = await _context.Genre
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
