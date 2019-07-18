using Microsoft.Extensions.Logging;
using SimplyBooks.Models;
using SimplyBooks.Models.ResultModels;
using System;
using System.Threading.Tasks;

namespace SimplyBooks.Repository.Commands.Nationalities
{
    public interface IAddNationalityCommand
    {
        Task<Result> Execute(Nationality nationality);
    }

    public class AddNationalityCommand : IAddNationalityCommand
    {
        private readonly SimplyBooksContext _context;
        private readonly ILogger<AddNationalityCommand> _logger;

        public AddNationalityCommand(SimplyBooksContext context,
            ILogger<AddNationalityCommand> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Result> Execute(Nationality nationality)
        {
            Result result = new Result();
            try
            {
                _context.Nationality.Add(nationality);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                var message = $"Exception thrown AddNationality:\n Message: {ex.Message}.\n Stacktrace: {ex.StackTrace}";
                result.AddError(message);
                _logger.LogError(message);
            }

            return result;
        }
    }
}
