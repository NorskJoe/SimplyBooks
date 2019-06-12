using SimplyBooks.Models;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace SimplyBooks.Repository.Commands.Books
{
    public interface IDeleteBookCommand
    {
        Task<HttpResponseMessage> Execute(int id);
    }

    public class DeleteBookCommand : IDeleteBookCommand
    {
        private readonly SimplyBooksContext _context;

        public DeleteBookCommand(SimplyBooksContext context)
        {
            _context = context;
        }

        public async Task<HttpResponseMessage> Execute(int id)
        {
            var book = new Book { BookId = id };

            try
            {
                _context.Book.Attach(book);
                _context.Book.Remove(book);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                //TODO
            }
            return new HttpResponseMessage(HttpStatusCode.OK);

        }
    }
}
