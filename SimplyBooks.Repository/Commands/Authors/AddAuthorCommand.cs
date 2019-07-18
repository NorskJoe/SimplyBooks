using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SimplyBooks.Models;
using SimplyBooks.Models.ResultModels;
using System;
using System.Threading.Tasks;

namespace SimplyBooks.Repository.Commands.Authors
{
    public interface IAddAuthorCommand
    {
        Task<Result> Execute(Author author);
    }

    public class AddAuthorCommand : IAddAuthorCommand
    {
        private readonly SimplyBooksContext _context;
        private readonly ILogger<AddAuthorCommand> _logger;

        public AddAuthorCommand(SimplyBooksContext context,
            ILogger<AddAuthorCommand> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Result> Execute(Author author)
        {
            Result result = new Result();
            try
            {
                // Do not save Nationality when adding Author
                _context.Entry(author.Nationality).State = EntityState.Unchanged;
                _context.Author.Add(author);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                var message = $"Exception thrown AddAuthor:\n Message: {ex.Message}.\n Stacktrace: {ex.StackTrace}";
                result.AddError(message);
                _logger.LogError(message);
            }

            return result;
        }
    }
}
