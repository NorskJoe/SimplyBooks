using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SimplyBooks.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SimplyBooks.Domain.Extensions;

namespace SimplyBooks.Repository.Queries.Authors
{
    public interface IAuthorSelectListQuery : IQuery<IList<AuthorSelectListItem>>
    {
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

        public async Task<IList<AuthorSelectListItem>> Execute()
        {
            var result = new List<AuthorSelectListItem>();

            try
            {
                result = await _context.Authors
                    .Join(_context.Nationalilties,
                        a => a.Nationality.NationalityId,
                        n => n.NationalityId,
                        (a, n) => new { a, n})
                    .Select(x => new AuthorSelectListItem
                    {
                        Name = x.a.Name,
                        AuthorId = x.a.AuthorId,
                        Nationality = new Nationality 
                        { 
                            Name = x.n.Name, 
                            NationalityId = x.n.NationalityId 
                        }
                    })
                    .OrderBy(x => x.Name)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogErrorWithEventId(ex);
            }

            return result;
        }
    }

    public class AuthorSelectListItem
    {
        public string Name { get; set; }
        public int AuthorId { get; set; }
        public Nationality Nationality { get; set; }
    }
}
