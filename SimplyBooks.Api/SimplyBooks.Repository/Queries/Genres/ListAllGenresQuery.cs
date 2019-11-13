using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SimplyBooks.Models;
using SimplyBooks.Models.ResultModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
                var message = $"Exception thrown ListAllGenress:\n Message: {ex.Message}.\n Stacktrace: {ex.StackTrace}";
                result.AddError(message);
                _logger.LogError(message);
            }

            return result;
        }
    }
}
