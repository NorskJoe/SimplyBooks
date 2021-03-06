﻿using Microsoft.Extensions.Logging;
using SimplyBooks.Models;
using System;
using System.Threading.Tasks;
using SimplyBooks.Models.Extensions;
using SimplyBooks.Models.QueryModels;

namespace SimplyBooks.Repository.Commands.Nationalities
{
    public interface IUpdateNationalityCommand
    {
        Task<Result> Execute(Nationality nationality);
    }

    public class UpdateNationalityCommand : IUpdateNationalityCommand
    {
        private readonly SimplyBooksContext _context;
        private readonly ILogger<UpdateNationalityCommand> _logger;

        public UpdateNationalityCommand(SimplyBooksContext context,
            ILogger<UpdateNationalityCommand> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Result> Execute(Nationality nationality)
        {
            Result result = new Result();
            try
            {
                _context.Nationality.Update(nationality);
                await _context.SaveChangesAsync();
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
