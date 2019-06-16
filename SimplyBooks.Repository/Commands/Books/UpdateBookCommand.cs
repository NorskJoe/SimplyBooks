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

        public UpdateBookCommand(SimplyBooksContext context)
        {
            _context = context;
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
                result.AddError($"Exception thrown UpdateBook:\n Message: {ex.Message}.\n Stacktrace: {ex.StackTrace}");
            }

            return result;
        }
    }
}
