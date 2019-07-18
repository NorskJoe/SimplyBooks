using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SimplyBooks.Models;
using SimplyBooks.Models.ResultModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimplyBooks.Repository.Queries.Authors
{
    public interface IListAllAuthorsQuery
    {
        Task<Result<IList<Author>>> Execute();
    }
    class ListAllAuthorsQuery : IListAllAuthorsQuery
    {
        private readonly SimplyBooksContext _context;
        private readonly ILogger<ListAllAuthorsQuery> _logger;

        public ListAllAuthorsQuery(SimplyBooksContext context,
            ILogger<ListAllAuthorsQuery> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Result<IList<Author>>> Execute()
        {
            Result<IList<Author>> result = new Result<IList<Author>>();

            try
            {
                result.Value = await _context.Author
                            .Include(b => b.Nationality)
                            .ToListAsync();
            }
            catch (Exception ex)
            {
                var message = $"Exception thrown ListAllAuthors:\n Message: {ex.Message}.\n Stacktrace: {ex.StackTrace}";
                result.AddError(message);
                _logger.LogError(message);
            }

            return result;
        }
    }
}
