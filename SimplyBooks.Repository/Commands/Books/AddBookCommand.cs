using SimplyBooks.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SimplyBooks.Repository.Commands.Books
{
    public interface IAddBookCommand
    {
        Task<HttpResponseMessage> Execute(Book book);
    }

    class AddBookCommand : IAddBookCommand
    {
        public Task<HttpResponseMessage> Execute(Book book)
        {
            throw new NotImplementedException();
        }
    }
}
