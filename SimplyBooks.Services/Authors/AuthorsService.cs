using SimplyBooks.Models;
using SimplyBooks.Models.Exceptions;
using SimplyBooks.Repository.Commands.Authors;
using System.Net.Http;
using System.Threading.Tasks;

namespace SimplyBooks.Services.Authors
{
    public interface IAuthorsService
    {
        Task<HttpResponseMessage> UpdateAuthorAsync(Author author);
        Task<HttpResponseMessage> AddAuthorAsync(Author author);
    }

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
                throw new EntityNotFoundException(author.Name);
            }
        }
    }
}
