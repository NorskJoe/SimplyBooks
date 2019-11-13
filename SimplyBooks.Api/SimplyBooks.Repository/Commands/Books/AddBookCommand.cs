using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SimplyBooks.Models;
using SimplyBooks.Models.ResultModels;
using System;
using System.Threading.Tasks;

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
                var message = $"Exception thrown AddBook:\n Message: {ex.Message}.\n Stacktrace: {ex.StackTrace}";
                result.AddError(message);
                _logger.LogError(message);
            }

            return result;
        }
    }
}
