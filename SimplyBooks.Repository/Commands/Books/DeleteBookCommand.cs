using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SimplyBooks.Repository.Commands.Books
{
    public interface IDeleteBookCommand
    {
        Task<HttpResponseMessage> Execute(int id);
    }

    class DeleteBookCommand : IDeleteBookCommand
    {
        public Task<HttpResponseMessage> Execute(int id)
        {
            throw new NotImplementedException();
        }
    }
}
