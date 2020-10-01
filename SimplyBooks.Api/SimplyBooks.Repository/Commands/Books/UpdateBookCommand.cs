using Microsoft.Extensions.Logging;
using SimplyBooks.Domain;
using System;
using System.Threading.Tasks;
using SimplyBooks.Domain.Extensions;
using SimplyBooks.Domain.QueryModels;

namespace SimplyBooks.Repository.Commands.Books
{
    public interface IUpdateBookCommand
    {
        Task<Result> Execute(Book book);
    }

    public class UpdateBookCommand : IUpdateBookCommand
    {
        private readonly SimplyBooksContext _context;
        private readonly ILogger<UpdateBookCommand> _logger;

        public UpdateBookCommand(SimplyBooksContext context,
            ILogger<UpdateBookCommand> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Result> Execute(Book book)
        {
            Result result = new Result();
            try
            {
                _context.Book.Update(book);
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
