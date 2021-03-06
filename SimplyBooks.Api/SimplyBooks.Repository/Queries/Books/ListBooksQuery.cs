﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SimplyBooks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SimplyBooks.Models.Extensions;
using SimplyBooks.Models.QueryModels;

namespace SimplyBooks.Repository.Queries.Books
{
    public interface IListAllBooksQuery
    {
        Task<Result<IList<BookListItem>>> Execute(BookListCriteria criteria);
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

                    if (!string.IsNullOrWhiteSpace(criteria.BookTitle))
                    {
                        query = query.Where(x => EF.Functions.Like(x.b.Title, $"%{criteria.BookTitle}%"));
                    }

                    if (criteria.YearRead.HasValue)
                    {
                        query = query.Where(x => x.b.DateRead.Year == criteria.YearRead.Value.Year);
                    }

                    if (criteria.YearPublished.HasValue)
                    {
                        query = query.Where(x => x.b.YearPublished.Year == criteria.YearPublished.Value.Year);
                    }

                    result.Value = await query
                                    .Select(x => new BookListItem
                                    {
                                        Title = x.b.Title,
                                        Author = x.a.Name,
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
                var id = _logger.LogErrorWithEventId(ex);
                var message = $"An unhandled exception occured.  An error has been logged with id: {id}";
                result.AddError(message);
            }

            return result;
        }
    }

    public class BookListCriteria : PagedCriteria
    {
        public string BookTitle { get; set; }
        public int? AuthorId { get; set; }
        public int? GenreId { get; set; }
        public DateTime? YearRead { get; set; }
        public DateTime? YearPublished { get; set; }
    }

    public class BookListItem
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Nationality { get; set; }
        public string Genre { get; set; }
        public double Rating { get; set; }
        public DateTime DateRead { get; set; }
        public DateTime YearPublished { get; set; }
    }
}
