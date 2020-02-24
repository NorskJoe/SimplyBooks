﻿using Microsoft.EntityFrameworkCore;
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
    public interface IListBooksByGenreQuery
    {
        Task<Result<IList<Book>>> Execute(int id);
    }

    public class ListBooksByGenreQuery : IListBooksByGenreQuery
    {
        private readonly SimplyBooksContext _context;
        private readonly ILogger<ListBooksByGenreQuery> _logger;

        public ListBooksByGenreQuery(SimplyBooksContext context,
            ILogger<ListBooksByGenreQuery> logger)
        {
            _context = context;
            _logger = logger;
        }


        public async Task<Result<IList<Book>>> Execute(int id)
        {
            Result<IList<Book>> result = new Result<IList<Book>>();

            try
            {
                result.Value = await _context.Book
                            .Include(b => b.Author)
                                .ThenInclude(a => a.Nationality)
                            .Include(b => b.Genre)
                            .Where(b => b.Genre.GenreId == id)
                            .ToListAsync();
            }
            catch (Exception ex)
            {
                var eventId = _logger.LogErrorWithEventId(ex);
                var message = $"An unhandled exception occured.  An error has been logged with id: {eventId}";
                result.AddError(message);
            }

            return result;
        }
    }
}
