using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SimplyBooks.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SimplyBooks.Domain.Extensions;
using SimplyBooks.Domain.QueryModels;

namespace SimplyBooks.Repository.Queries.Books
{
    public interface IListAllBooksQuery : IPagedQuery<IList<BookListItem>, BookListCriteria>
    {
    }

    public class ListBooksQuery : IListAllBooksQuery
    {
        private readonly SimplyBooksContext _context;
        private readonly ILogger<ListBooksQuery> _logger;

        public ListBooksQuery(SimplyBooksContext context,
            ILogger<ListBooksQuery> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IList<BookListItem>> Execute(BookListCriteria criteria)
        {
            var result = new List<BookListItem>();

            try
            {
                var query = _context.Books
                    .Join(_context.Authors,
                        b => b.Author.AuthorId,
                        a => a.AuthorId,
                        (b, a) => new {b, a})
                    .Join(_context.Nationalilties,
                        x => x.a.Nationality.NationalityId,
                        n => n.NationalityId,
                        (x, n) => new {x.b, x.a, n})
                    .Join(_context.Genres,
                        x => x.b.Genre.GenreId,
                        g => g.GenreId,
                        (x, g) => new {x.b, x.a, x.n, g});

                    /*
                     * FILTER CRITERIA
                     */
                    if (criteria.AuthorId.HasValue)
                    {
                        query = query.Where(x => x.a.AuthorId == criteria.AuthorId);
                    }

                    if (criteria.GenreId.HasValue)
                    {
                        query = query.Where(x => x.g.GenreId == criteria.GenreId);
                    }

                    if (!string.IsNullOrWhiteSpace(criteria.BookTitle))
                    {
                        query = query.Where(x => EF.Functions.Like(x.b.Title, $"%{criteria.BookTitle}%"));
                    }

                    if (criteria.YearRead.HasValue)
                    {
                        query = query.Where(x => x.b.DateRead.Year == criteria.YearRead);
                    }

                    if (criteria.YearPublished.HasValue)
                    {
                        query = query.Where(x => x.b.YearPublished.Year == criteria.YearPublished);
                    }

                /*
                 * SORT CRITERIA
                 */
                switch (criteria.OrderField)
                {
                    case "title":
                        query = query.OrderByDynamic(x => x.b.Title, criteria.OrderDirection);
                        break;
                    case "author":
                        query = query.OrderByDynamic(x => x.a.Name, criteria.OrderDirection);
                        break;
                    case "genre":
                        query = query.OrderByDynamic(x => x.g.Name, criteria.OrderDirection);
                        break;
                    case "nationality":
                        query = query.OrderByDynamic(x => x.n.Name, criteria.OrderDirection);
                        break;
                    case "rating":
                        query = query.OrderByDynamic(x => x.b.Rating, criteria.OrderDirection);
                        break;
                    case "dateRead":
                        query = query.OrderByDynamic(x => x.b.DateRead, criteria.OrderDirection);
                        break;
                    case "yearPublished":
                        query = query.OrderByDynamic(x => x.b.YearPublished, criteria.OrderDirection);
                        break;
                    default:
                        query = query.OrderByDynamic(x => x.b.Title, OrderDirection.ASC);
                        break;
                }

                result = await query
                    .Select(x => new BookListItem
                    {
                        Title = x.b.Title,
                        AuthorName = x.a.Name,
                        Nationality = x.n.Name,
                        Genre = x.g.Name,
                        Rating = x.b.Rating,
                        DateRead = x.b.DateRead,
                        YearPublished = x.b.YearPublished
                    })
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogErrorWithEventId(ex);
            }

            return result;
        }
    }

    public class BookListCriteria : PagedCriteria
    {
        public string BookTitle { get; set; }
        public int? AuthorId { get; set; }
        public int? GenreId { get; set; }
        public int? YearRead { get; set; }
        public int? YearPublished { get; set; }
    }

    public class BookListItem
    {
        public string Title { get; set; }
        public string AuthorName { get; set; }
        public string Nationality { get; set; }
        public string Genre { get; set; }
        public double Rating { get; set; }
        public DateTime DateRead { get; set; }
        public DateTime YearPublished { get; set; }
    }
}
