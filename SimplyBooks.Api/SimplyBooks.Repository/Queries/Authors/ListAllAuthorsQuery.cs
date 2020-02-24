using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SimplyBooks.Models;
using SimplyBooks.Models.ResultModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SimplyBooks.Models.Extensions;

namespace SimplyBooks.Repository.Queries.Authors
{
    public interface IListAllAuthorsQuery
    {
        Task<Result<IList<Author>>> Execute();
    }
    public class ListAllAuthorsQuery : IListAllAuthorsQuery
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
                            .Include(a => a.Nationality)
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
