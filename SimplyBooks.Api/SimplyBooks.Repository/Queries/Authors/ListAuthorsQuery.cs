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
    public interface IListAuthorsQuery
    {
        Task<Result<IList<AuthorListItem>>> Execute(AuthorListCriteria criteria);
    }
    public class ListAuthorsQuery : IListAuthorsQuery
    {
        private readonly SimplyBooksContext _context;
        private readonly ILogger<ListAuthorsQuery> _logger;

        public ListAuthorsQuery(SimplyBooksContext context,
            ILogger<ListAuthorsQuery> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Result<IList<AuthorListItem>>> Execute(AuthorListCriteria criteria)
        {
            Result<IList<AuthorListItem>> result = new Result<IList<AuthorListItem>>();

            try
            {
                var query = _context.Author
                    .Join(_context.Nationality,
                        a => a.Nationality.NationalityId,
                        n => n.NationalityId,
                        (a, n) => new { a, n })
                    .Join(_context.Book,
                        x => x.a.AuthorId,
                        b => b.Author.AuthorId,
                        (x, b) => new { x.a, x.n, b });

                if (!string.IsNullOrWhiteSpace(criteria.AuthorName))
                {
                    query = query.Where(x => EF.Functions.Like(x.a.Name, $"%{criteria.AuthorName}%"));
                }

                if (criteria.NationalityId.HasValue)
                {
                    query = query.Where(x => x.n.NationalityId == criteria.NationalityId);
                }


                result.Value = await query
                    .GroupBy(x => new { Name = x.a.Name, Nationality = x.n.Name })
                    .Select(x => new AuthorListItem
                    {
                        Name = x.Key.Name,
                        Nationality = x.Key.Nationality,
                        AverageRating = x.Average(x => x.b.Rating),
                        BooksRead = x.Count()
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

    public class AuthorListCriteria : PagedCriteria
    {
        public string AuthorName{ get; set; }
        public int? NationalityId { get; set; }
    }

    public class AuthorListItem
    {
        public string Name { get; set; }
        public string Nationality { get; set; }
        public double AverageRating { get; set; }
        public int BooksRead { get; set; }
    }
}
