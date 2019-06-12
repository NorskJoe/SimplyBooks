using SimplyBooks.Models;
using System;
using System.Threading.Tasks;

namespace SimplyBooks.Repository.Commands.Books
{
    public interface IAddBookCommand
    {
        Task<Book> Execute(Book book);
    }

    public class AddBookCommand : IAddBookCommand
    {
        private readonly SimplyBooksContext _context;

        public AddBookCommand(SimplyBooksContext context)
        {
            _context = context;
        }

        public async Task<Book> Execute(Book book)
        {
            try
            {
                _context.Book.Add(book);
                 await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                // TODO
            }
            return book;
        }
    }
}
