using SimplyBooks.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SimplyBooks.Repository.Commands.Authors
{
    public interface IAddAuthorCommand
    {
        Task<HttpResponseMessage> AddAuthor(Author author);
    }

    class AddAuthorCommand : IAddAuthorCommand
    {
        public Task<HttpResponseMessage> AddAuthor(Author author)
        {
            throw new NotImplementedException();
        }
    }
}
