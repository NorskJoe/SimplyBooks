using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SimplyBooks.Models;
using System;
using System.Threading.Tasks;
using SimplyBooks.Models.Extensions;
using SimplyBooks.Models.QueryModels;

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
                var id = _logger.LogErrorWithEventId(ex);
                var message = $"An unhandled exception occured.  An error has been logged with id: {id}";
                result.AddError(message);
            }

            return result;
        }
    }
}
