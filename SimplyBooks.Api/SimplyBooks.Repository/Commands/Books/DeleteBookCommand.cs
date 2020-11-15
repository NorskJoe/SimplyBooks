using Microsoft.Extensions.Logging;
using SimplyBooks.Domain;
using System;
using System.Threading.Tasks;
using SimplyBooks.Domain.Extensions;
using SimplyBooks.Domain.QueryModels;

namespace SimplyBooks.Repository.Commands.Books
{
    public interface IDeleteBookCommand : ICommand<DeleteBookCriteria>
    {
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

        public async Task<Result> Execute(DeleteBookCriteria criteria)
        {
            Result result = new Result();
            var book = new Book { BookId = criteria.BookId };

            try
            {
                _context.Books.Remove(book);
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

    public class DeleteBookCriteria
    {
        public int BookId { get; set; }
    }
}
