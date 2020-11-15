using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SimplyBooks.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SimplyBooks.Domain.Extensions;

namespace SimplyBooks.Repository.Queries.Genres
{
    public interface IGenreSelectListQuery : IQuery<IList<GenreSelectListItem>>
    {
    }

    public class GenreSelectListQuery : IGenreSelectListQuery
    {
        private readonly SimplyBooksContext _context;
        private readonly ILogger<GenreSelectListQuery> _logger;

        public GenreSelectListQuery(SimplyBooksContext context,
            ILogger<GenreSelectListQuery> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IList<GenreSelectListItem>> Execute()
        {
            var result = new List<GenreSelectListItem>();

            try
            {
                result = await _context.Genres
                    .Select(x => new GenreSelectListItem
                    {
                        Name = x.Name,
                        GenreId = x.GenreId
                    })
                    .OrderBy(x => x.Name)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                var id = _logger.LogErrorWithEventId(ex);
                var message = $"An unhandled exception occured.  An error has been logged with id: {id}";
            }

            return result;
        }
    }

    public class GenreSelectListItem
    {
        public string Name { get; set; }
        public int GenreId { get; set; }
    }
}
