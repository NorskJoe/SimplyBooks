using SimplyBooks.Models;
using SimplyBooks.Models.ResultModels;
using System;
using System.Threading.Tasks;

namespace SimplyBooks.Repository.Commands.Books
{
    public interface IDeleteBookCommand
    {
        Task<Result> Execute(int id);
    }

    public class DeleteBookCommand : IDeleteBookCommand
    {
        private readonly SimplyBooksContext _context;

        public DeleteBookCommand(SimplyBooksContext context)
        {
            _context = context;
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
                result.AddError($"Exception thrown DeleteBook:\n Message: {ex.Message}.\n Stacktrace: {ex.StackTrace}");
            }

            return result;
        }
    }
}
