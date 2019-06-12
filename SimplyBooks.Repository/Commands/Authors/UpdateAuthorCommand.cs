using SimplyBooks.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SimplyBooks.Repository.Commands.Authors
{
    public interface IUpdateAuthorCommand
    {
        Task<HttpResponseMessage> UpdateAuthor(Author author);
    }

    public class UpdateAuthorCommand : IUpdateAuthorCommand
    {
        public Task<HttpResponseMessage> UpdateAuthor(Author author)
        {
            throw new NotImplementedException();
        }
    }
}
