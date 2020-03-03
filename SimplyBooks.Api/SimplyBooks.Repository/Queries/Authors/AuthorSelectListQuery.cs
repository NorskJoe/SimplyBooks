using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SimplyBooks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SimplyBooks.Models.Extensions;
using SimplyBooks.Models.QueryModels;

namespace SimplyBooks.Repository.Queries.Authors
{
    public interface IAuthorSelectListQuery
    {
        Task<Result<IList<AuthorSelectListItem>>> Execute();
    }
    public class AuthorSelectListQuery : IAuthorSelectListQuery
    {
        private readonly SimplyBooksContext _context;
        private readonly ILogger<AuthorSelectListQuery> _logger;

        public AuthorSelectListQuery(SimplyBooksContext context,
            ILogger<AuthorSelectListQuery> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Result<IList<AuthorSelectListItem>>> Execute()
        {
            var result = new Result<IList<AuthorSelectListItem>>();

            try
            {
                result.Value = await _context.Author
                    .Select(x => new AuthorSelectListItem
                    {
                        Name = x.Name,
                        AuthorId = x.AuthorId
                    })
                    .OrderBy(x => x.Name)
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
    public class AuthorSelectListItem
    {
        public string Name { get; set; }
        public int AuthorId { get; set; }
    }
}
