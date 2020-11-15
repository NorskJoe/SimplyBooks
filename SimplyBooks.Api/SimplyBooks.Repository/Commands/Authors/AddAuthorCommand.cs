using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SimplyBooks.Domain;
using System;
using System.Threading.Tasks;
using SimplyBooks.Domain.Extensions;
using SimplyBooks.Domain.QueryModels;

namespace SimplyBooks.Repository.Commands.Authors
{
    public interface IAddAuthorCommand : ICommand<Author>
    {
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
                // Do not add new Nationality when adding Author
                _context.Entry(author.Nationality).State = EntityState.Unchanged;
                _context.Authors.Add(author);
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
