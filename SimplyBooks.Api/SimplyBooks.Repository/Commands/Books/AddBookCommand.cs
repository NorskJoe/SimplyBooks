using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SimplyBooks.Models;
using System;
using System.Threading.Tasks;
using SimplyBooks.Models.Extensions;
using SimplyBooks.Models.QueryModels;

namespace SimplyBooks.Repository.Commands.Books
{
    public interface IAddBookCommand
    {
        Task<Result> Execute(Book book);
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
                _context.Book.Add(book);
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
