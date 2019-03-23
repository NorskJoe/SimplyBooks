using SimplyBooks.Repository.Commands.Interfaces.Books;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SimplyBooks.Repository.Commands.Concrete.Books
{
    class DeleteBookCommand : IDeleteBookCommand
    {
        public Task<HttpResponseMessage> Execute(int id)
        {
            throw new NotImplementedException();
        }
    }
}
