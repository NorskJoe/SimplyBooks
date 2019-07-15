using SimplyBooks.Models;
using SimplyBooks.Models.Exceptions;
using SimplyBooks.Models.ResultModels;
using SimplyBooks.Repository.Commands.Authors;
using SimplyBooks.Repository.Queries.Authors;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace SimplyBooks.Services.Authors
{
    public interface IAuthorsService
    {
        Task<Result<List<Author>>> ListAllAuthorsAsync();
        Task<Result> AddAuthorAsync(Author author);
        Task<Result> UpdateAuthorAsync(Author author);
    }

    public class AuthorsService : IAuthorsService
    {
        private readonly IAddAuthorCommand _addAuthorCommand;
        private readonly IUpdateAuthorCommand _updateAuthorCommand;
        private readonly IListAllAuthorsQuery _listAllAuthorsQuery;

        public AuthorsService(IAddAuthorCommand addAuthorCommand,
            IUpdateAuthorCommand updateAuthorCommand,
            IListAllAuthorsQuery listAllAuthorsQuery)
        {
            _listAllAuthorsQuery = listAllAuthorsQuery;
            _addAuthorCommand = addAuthorCommand;
            _updateAuthorCommand = updateAuthorCommand;
        }

        public async Task<Result<List<Author>>> ListAllAuthorsAsync()
        {
            return await _listAllAuthorsQuery.Execute();
        }

        public async Task<Result> AddAuthorAsync(Author author)
        {
            return await _addAuthorCommand.Execute(author);
        }

        public async Task<Result> UpdateAuthorAsync(Author author)
        {
            return await _updateAuthorCommand.Execute(author);
        }
    }
}
