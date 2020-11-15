﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SimplyBooks.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SimplyBooks.Domain.Extensions;
using SimplyBooks.Domain.QueryModels;

namespace SimplyBooks.Repository.Queries.Authors
{
    public interface IListAuthorsQuery : IQuery<List<AuthorListItem>, AuthorListCriteria>
    {
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

        public async Task<List<AuthorListItem>> Execute(AuthorListCriteria criteria)
        {
            var result = new List<AuthorListItem>();

            try
            {
                var query = from b in _context.Book
                            join a in _context.Author on b.Author.AuthorId equals a.AuthorId
                            join n in _context.Nationality on a.Nationality.NationalityId equals n.NationalityId
                            select new 
                            { 
                                Name = a.Name,
                                Nationality = n.Name, 
                                Rating = b.Rating, 
                                NationalityId = n.NationalityId 
                            };

                if (!string.IsNullOrWhiteSpace(criteria.AuthorName))
                {
                    query = query.Where(x => EF.Functions.Like(x.Name, $"%{criteria.AuthorName}%"));
                }

                if (criteria.NationalityId.HasValue)
                {
                    query = query.Where(x => x.NationalityId == criteria.NationalityId);
                }

                result = await query
                    .GroupBy(x => new { Name = x.Name, Nationality = x.Name })
                    .Select(x => new AuthorListItem
                    {
                        Name = x.Key.Name,
                        Nationality = x.Key.Nationality,
                        AverageRating = x.Average(x => x.Rating),
                        BooksRead = x.Count()
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