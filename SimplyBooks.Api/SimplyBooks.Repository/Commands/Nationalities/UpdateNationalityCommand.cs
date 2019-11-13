using Microsoft.Extensions.Logging;
using SimplyBooks.Models;
using SimplyBooks.Models.ResultModels;
using System;
using System.Threading.Tasks;

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
                var message = $"Exception thrown UpdateNationality:\n Message: {ex.Message}.\n Stacktrace: {ex.StackTrace}";
                result.AddError(message);
                _logger.LogError(message);
                throw;
            }

            return result;
        }
    }
}
