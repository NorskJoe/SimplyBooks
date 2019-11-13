using Microsoft.Extensions.Logging;
using SimplyBooks.Models;
using SimplyBooks.Models.ResultModels;
using System;
using System.Threading.Tasks;

namespace SimplyBooks.Repository.Commands.Genres
{
    public interface IUpdateGenreCommand
    {
        Task<Result> Execute(Genre genre);
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
                _context.Genre.Update(genre);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                var message = $"Exception thrown UpdateGenre:\n Message: {ex.Message}.\n Stacktrace: {ex.StackTrace}";
                result.AddError(message);
                _logger.LogError(message);
                throw;
            }

            return result;
        }
    }
}
