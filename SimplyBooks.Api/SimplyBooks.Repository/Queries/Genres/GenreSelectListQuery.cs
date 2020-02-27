using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SimplyBooks.Models;
using SimplyBooks.Models.ResultModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SimplyBooks.Models.Extensions;

namespace SimplyBooks.Repository.Queries.Genres
{
    public interface IGenreSelectListQuery
    {
        Task<Result<IList<GenreSelectListItem>>> Execute();
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

        public async Task<Result<IList<GenreSelectListItem>>> Execute()
        {
            var result = new Result<IList<GenreSelectListItem>>();

            try
            {
                result.Value = await _context.Genre
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
                result.AddError(message);
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
