using SimplyBooks.Models;
using SimplyBooks.Repository.Commands.Interfaces.Authors;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SimplyBooks.Repository.Commands.Concrete.Authors
{
    class AddAuthorCommand : IAddAuthorCommand
    {
        public Task<HttpResponseMessage> AddAuthor(Author author)
        {
            throw new NotImplementedException();
        }
    }
}
