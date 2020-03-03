using Microsoft.Extensions.Logging;
using SimplyBooks.Models;
using System;
using System.Threading.Tasks;
using SimplyBooks.Models.Extensions;
using SimplyBooks.Models.QueryModels;

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
                var id = _logger.LogErrorWithEventId(ex);
                var message = $"An unhandled exception occured.  An error has been logged with id: {id}";
                result.AddError(message);
            }

            return result;
        }
    }
}
