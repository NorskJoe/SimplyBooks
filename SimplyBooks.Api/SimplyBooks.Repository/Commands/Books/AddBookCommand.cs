using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SimplyBooks.Domain;
using System;
using System.Threading.Tasks;
using SimplyBooks.Domain.Extensions;
using SimplyBooks.Domain.QueryModels;

namespace SimplyBooks.Repository.Commands.Books
{
    public interface IAddBookCommand : ICommand<Book>
    {
    }

    public class AddBookCommand : IAddBookCommand
    {
        private readonly SimplyBooksContext _context;
        private readonly ILogger<AddBookCommand> _logger;

        public AddBookCommand(SimplyBooksContext context,
            ILogger<AddBookCommand> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Result> Execute(Book book)
        {
            Result result = new Result();
            try
            {
                // Do not add Author/Genre/Nationality when adding book
                _context.Entry(book.Author).State = EntityState.Unchanged;
                _context.Entry(book.Author.Nationality).State = EntityState.Unchanged;
                _context.Entry(book.Genre).State = EntityState.Unchanged;
                _context.Books.Add(book);
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
