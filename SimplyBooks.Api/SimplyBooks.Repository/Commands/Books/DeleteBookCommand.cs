using Microsoft.Extensions.Logging;
using SimplyBooks.Models;
using SimplyBooks.Models.ResultModels;
using System;
using System.Threading.Tasks;
using SimplyBooks.Models.Extensions;

namespace SimplyBooks.Repository.Commands.Books
{
    public interface IDeleteBookCommand
    {
        Task<Result> Execute(int id);
    }

    public class DeleteBookCommand : IDeleteBookCommand
    {
        private readonly SimplyBooksContext _context;
        private readonly ILogger<DeleteBookCommand> _logger;

        public DeleteBookCommand(SimplyBooksContext context,
            ILogger<DeleteBookCommand> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Result> Execute(int id)
        {
            Result result = new Result();
            var book = new Book { BookId = id };

            try
            {
                _context.Book.Remove(book);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                var eventId = _logger.LogErrorWithEventId(ex);
                var message = $"An unhandled exception occured.  An error has been logged with id: {eventId}";
                result.AddError(message);
            }

            return result;
        }
    }
}
