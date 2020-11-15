using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SimplyBooks.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SimplyBooks.Domain.Extensions;

namespace SimplyBooks.Repository.Queries.Nationalities
{
    public interface INationalitySelectListQuery : IQuery<IList<NationalitySelectListItem>>
    {
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

        public async Task<IList<NationalitySelectListItem>> Execute()
        {
            var result = new List<NationalitySelectListItem>();

            try
            {
                result = await _context.Nationalilties
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
