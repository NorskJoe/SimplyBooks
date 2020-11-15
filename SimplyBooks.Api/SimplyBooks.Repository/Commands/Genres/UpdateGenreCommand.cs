using Microsoft.Extensions.Logging;
using SimplyBooks.Domain;
using System;
using System.Threading.Tasks;
using SimplyBooks.Domain.Extensions;
using SimplyBooks.Domain.QueryModels;

namespace SimplyBooks.Repository.Commands.Genres
{
    public interface IUpdateGenreCommand : ICommand<Genre>
    {
    }

    public class UpdateGenreCommand : IUpdateGenreCommand
    {
        private readonly SimplyBooksContext _context;
        private readonly ILogger<UpdateGenreCommand> _logger;

        public UpdateGenreCommand(SimplyBooksContext context,
            ILogger<UpdateGenreCommand> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Result> Execute(Genre genre)
        {
            Result result = new Result();
            try
            {
                _context.Genres.Update(genre);
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
