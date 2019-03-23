using SimplyBooks.Models;
using SimplyBooks.Models.Exceptions;
using SimplyBooks.Repository.Commands.Interfaces.Authors;
using SimplyBooks.Services.Authors.Interfaces;
using SimplyBooks.Services.Genres.Concrete;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace SimplyBooks.Services.Authors.Concrete
{
    class AuthorsService : IAuthorsService
    {
        private readonly IAddAuthorCommand _addAuthorCommand;
        private readonly IUpdateAuthorCommand _updateAuthorCommand;

        public AuthorsService(IAddAuthorCommand addAuthorCommand,
            IUpdateAuthorCommand updateAuthorCommand)
        {
            _addAuthorCommand = addAuthorCommand;
            _updateAuthorCommand = updateAuthorCommand;
        }

        public async Task<HttpResponseMessage> AddAuthorAsync(Author author)
        {
            var response = await _addAuthorCommand.AddAuthor(author);

            if (response.IsSuccessStatusCode)
            {
                return response;
            }
            else
            {
                throw new EntityAlreadyExistsException(author.Name);
            }
        }

        public async Task<HttpResponseMessage> UpdateAuthorAsync(Author author)
        {
            var response = await _updateAuthorCommand.UpdateAuthor(author);

            if (response.IsSuccessStatusCode)
            {
                return response;
            }
            else
            {
                throw new HttpResponseException(HttpStatusCode.NotModified);
            }
        }
    }
}
