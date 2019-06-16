using Microsoft.EntityFrameworkCore;
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

        public AddBookCommand(SimplyBooksContext context)
        {
            _context = context;
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
                result.AddError($"Exception thrown AddBook:\n Message: {ex.Message}.\n Stacktrace: {ex.StackTrace}");
            }

            return result;
        }
    }
}
