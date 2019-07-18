using Microsoft.Extensions.Logging;
using SimplyBooks.Models;
using SimplyBooks.Models.ResultModels;
using System;
using System.Threading.Tasks;

namespace SimplyBooks.Repository.Commands.Genres
{
    public interface IAddGenreCommand
    {
        Task<Result> Execute(Genre genre);
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
                var message = $"Exception thrown AddGenre:\n Message: {ex.Message}.\n Stacktrace: {ex.StackTrace}";
                result.AddError(message);
                _logger.LogError(message);
            }

            return result;
        }
    }
}
