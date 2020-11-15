using Microsoft.Extensions.Logging;
using SimplyBooks.Domain;
using System;
using System.Threading.Tasks;
using SimplyBooks.Domain.Extensions;
using SimplyBooks.Domain.QueryModels;

namespace SimplyBooks.Repository.Commands.Nationalities
{
    public interface IAddNationalityCommand : ICommand<Nationality>
    {
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
                _context.Nationalilties.Add(nationality);
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
