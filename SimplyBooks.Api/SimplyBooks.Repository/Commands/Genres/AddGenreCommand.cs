using Microsoft.Extensions.Logging;
using SimplyBooks.Domain;
using System;
using System.Threading.Tasks;
using SimplyBooks.Domain.Extensions;
using SimplyBooks.Domain.QueryModels;

namespace SimplyBooks.Repository.Commands.Genres
{
    public interface IAddGenreCommand : ICommand<Genre>
    {
    }

    public class AddGenreCommand : IAddGenreCommand
    {
        private readonly SimplyBooksContext _context;
        private readonly ILogger<AddGenreCommand> _logger;

        public AddGenreCommand(SimplyBooksContext context,
            ILogger<AddGenreCommand> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Result> Execute(Genre genre)
        {
            Result result = new Result();
            try
            {
                _context.Genre.Add(genre);
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
