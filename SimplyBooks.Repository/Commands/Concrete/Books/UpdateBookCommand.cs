using SimplyBooks.Models;
using SimplyBooks.Repository.Commands.Interfaces.Books;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SimplyBooks.Repository.Commands.Concrete.Books
{
    class UpdateBookCommand : IUpdateBookCommand
    {
        public Task<HttpResponseMessage> Execute(Book book)
        {
            throw new NotImplementedException();
        }
    }
}
