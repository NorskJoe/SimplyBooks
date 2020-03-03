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
    public interface IListAllAuthorsQuery
    {
        Task<Result<IList<AuthorItem>>> Execute();
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

        public async Task<Result<IList<AuthorItem>>> Execute()
        {
            Result<IList<AuthorItem>> result = new Result<IList<AuthorItem>>();

            try
            {
                result.Value = await _context.Author
                    .Join(_context.Nationality,
                        a => a.Nationality.NationalityId,
                        n => n.NationalityId,
                        (a, n) => new {a, n})
                    .Select(x => new AuthorItem
                    {
                        Name = x.a.Name,
                        Nationality = x.n.Name
                    })
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
    public class AuthorItem
    {
        public string Name { get; set; }
        public string Nationality { get; set; }
    }
}
