using Microsoft.Extensions.Logging;
using SimplyBooks.Domain;
using System;
using System.Threading.Tasks;
using SimplyBooks.Domain.Extensions;
using SimplyBooks.Domain.QueryModels;

namespace SimplyBooks.Repository.Commands.Authors
{
    public interface IUpdateAuthorCommand : ICommand<Author>
    {
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
