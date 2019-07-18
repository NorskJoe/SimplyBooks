using Microsoft.Extensions.Logging;
using SimplyBooks.Models;
using SimplyBooks.Models.ResultModels;
using System;
using System.Threading.Tasks;

namespace SimplyBooks.Repository.Commands.Authors
{
    public interface IUpdateAuthorCommand
    {
        Task<Result> Execute(Author author);
    }

    public class UpdateAuthorCommand : IUpdateAuthorCommand
    {
        private readonly SimplyBooksContext _context;
        private readonly ILogger<UpdateAuthorCommand> _logger;

        public UpdateAuthorCommand(SimplyBooksContext context,
            ILogger<UpdateAuthorCommand> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Result> Execute(Author author)
        {
            Result result = new Result();
            try
            {
                _context.Author.Update(author);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                var message = $"Exception thrown UpdateAuthor:\n Message: {ex.Message}.\n Stacktrace: {ex.StackTrace}";
                result.AddError(message);
                _logger.LogError(message);
                throw;
            }

            return result;
        }
    }
}
