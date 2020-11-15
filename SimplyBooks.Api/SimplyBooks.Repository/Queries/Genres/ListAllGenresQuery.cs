﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SimplyBooks.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SimplyBooks.Domain.Extensions;
using SimplyBooks.Domain.QueryModels;

namespace SimplyBooks.Repository.Queries.Genres
{
    public interface IListAllGenresQuery
    {
        Task<Result<IList<Genre>>> Execute();
    }

    public class ListAllGenresQuery : IListAllGenresQuery
    {
        private readonly SimplyBooksContext _context;
        private readonly ILogger<ListAllGenresQuery> _logger;

        public ListAllGenresQuery(SimplyBooksContext context,
            ILogger<ListAllGenresQuery> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Result<IList<Genre>>> Execute()
        {
            Result<IList<Genre>> result = new Result<IList<Genre>>();

            try
            {
                result.Value = await _context.Genres
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
}
