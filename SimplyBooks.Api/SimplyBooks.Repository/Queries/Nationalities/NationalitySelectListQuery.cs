using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SimplyBooks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SimplyBooks.Models.Extensions;
using SimplyBooks.Models.QueryModels;

namespace SimplyBooks.Repository.Queries.Nationalities
{
    public interface INationalitySelectListQuery
    {
        Task<Result<IList<NationalitySelectListItem>>> Execute();
    }
    public class NationalitySelectListQuery : INationalitySelectListQuery
    {
        private readonly SimplyBooksContext _context;
        private readonly ILogger<NationalitySelectListQuery> _logger;

        public NationalitySelectListQuery(SimplyBooksContext context,
            ILogger<NationalitySelectListQuery> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Result<IList<NationalitySelectListItem>>> Execute()
        {
            var result = new Result<IList<NationalitySelectListItem>>();

            try
            {
                result.Value = await _context.Nationality
                    .Select(x => new NationalitySelectListItem
                    {
                        Name = x.Name,
                        NationalityId = x.NationalityId
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
    public class NationalitySelectListItem
    {
        public string Name { get; set; }
        public int NationalityId { get; set; }
    }
}
