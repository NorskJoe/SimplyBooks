using SimplyBooks.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SimplyBooks.Repository.Commands.Books
{
    public interface IUpdateBookCommand
    {
        Task<HttpResponseMessage> Execute(Book book);
    }

    public class UpdateBookCommand : IUpdateBookCommand
    {
        public Task<HttpResponseMessage> Execute(Book book)
        {
            throw new NotImplementedException();
        }
    }
}
