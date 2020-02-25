using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SimplyBooks.Models;
using SimplyBooks.Models.ResultModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SimplyBooks.Models.Extensions;

namespace SimplyBooks.Repository.Queries.Books
{
    public interface IListAllBooksQuery
    {
        Task<Result<IList<BookListItem>>> Execute(BookListCriteria criteria);
    }

    public class ListAllBooksQuery : IListAllBooksQuery
    {
        private readonly SimplyBooksContext _context;
        private readonly ILogger<ListAllBooksQuery> _logger;

        public ListAllBooksQuery(SimplyBooksContext context,
            ILogger<ListAllBooksQuery> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Result<IList<BookListItem>>> Execute(BookListCriteria criteria)
        {
            var result = new Result<IList<BookListItem>>();

            try
            {
                var query = _context.Book
                    .Join(_context.Author,
                        b => b.Author.AuthorId,
                        a => a.AuthorId,
                        (b, a) => new {b, a})
                    .Join(_context.Nationality,
                        x => x.a.Nationality.NationalityId,
                        n => n.NationalityId,
                        (x, n) => new {x.b, x.a, n})
                    .Join(_context.Genre,
                        x => x.b.Genre.GenreId,
                        g => g.GenreId,
                        (x, g) => new {x.b, x.a, x.n, g});

                    if (criteria.AuthorId.HasValue)
                    {
                        query = query.Where(x => x.a.AuthorId == criteria.AuthorId);
                    }

                    if (criteria.GenreId.HasValue)
                    {
                        query = query.Where(x => x.g.GenreId == criteria.GenreId);
                    }

                    if (criteria.NationalityId.HasValue)
                    {
                        query = query.Where(x => x.n.NationalityId == criteria.NationalityId);
                    }

                    if (criteria.DateRead.HasValue)
                    {
                        query = query.Where(x => x.b.DateRead == criteria.DateRead);
                    }

                    if (criteria.YearPublished.HasValue)
                    {
                        query = query.Where(x => x.b.YearPublished == criteria.YearPublished);
                    }

                    result.Value = await query
                                    .Select(x => new BookListItem
                                    {
                                        Title = x.b.Title,
                                        Author = x.a.Name,
                                        Nationality = x.n.Name,
                                        Genre = x.g.Name,
                                        Rating = x.b.Rating,
                                        DateRead = x.b.DateRead.ToShortDateString(),
                                        YearPublished = x.b.YearPublished.Year.ToString()
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

    public class BookListCriteria
    {
        public int? NationalityId { get; set; }
        public int? AuthorId { get; set; }
        public int? GenreId { get; set; }
        public DateTime? DateRead { get; set; }
        public DateTime? YearPublished { get; set; }
    }

    public class BookListItem
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Nationality { get; set; }
        public string Genre { get; set; }
        public double Rating { get; set; }
        public string DateRead { get; set; }
        public string YearPublished { get; set; }
    }
}
