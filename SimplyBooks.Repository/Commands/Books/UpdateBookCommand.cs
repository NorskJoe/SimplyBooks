using Microsoft.Extensions.Logging;
using SimplyBooks.Models;
using SimplyBooks.Models.ResultModels;
using System;
using System.Threading.Tasks;

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
                var message = $"Exception thrown UpdateBook:\n Message: {ex.Message}.\n Stacktrace: {ex.StackTrace}";
                result.AddError(message);
                _logger.LogError(message);
            }

            return result;
        }
    }
}
