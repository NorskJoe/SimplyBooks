using SimplyBooks.Models;
using SimplyBooks.Models.ResultModels;
using SimplyBooks.Repository.Commands.Authors;
using SimplyBooks.Repository.Queries.Authors;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimplyBooks.Services.Authors
{
    public interface IAuthorsService
    {
        Task<Result<AuthorList>> ListAllAuthorsAsync();
        Task<Result<AuthorSelectList>> SelectList();
        Task<Result> AddAuthorAsync(Author author);
        Task<Result> UpdateAuthorAsync(Author author);
    }

    public class AuthorsService : IAuthorsService
    {
        private readonly IAddAuthorCommand _addAuthorCommand;
        private readonly IUpdateAuthorCommand _updateAuthorCommand;
        private readonly IListAllAuthorsQuery _listAllAuthorsQuery;
        private readonly IAuthorSelectListQuery _authorSelectListQuery;

        public AuthorsService(IAddAuthorCommand addAuthorCommand,
            IUpdateAuthorCommand updateAuthorCommand,
            IListAllAuthorsQuery listAllAuthorsQuery,
            IAuthorSelectListQuery authorSelectListQuery)
        {
            _listAllAuthorsQuery = listAllAuthorsQuery;
            _addAuthorCommand = addAuthorCommand;
            _updateAuthorCommand = updateAuthorCommand;
            _authorSelectListQuery = authorSelectListQuery;
        }

        public async Task<Result<AuthorList>> ListAllAuthorsAsync()
        {
            var result = new Result<AuthorList>();

            var queryResult = await _listAllAuthorsQuery.Execute();

            if (queryResult.IsSuccess)
            {
                result.Value = new AuthorList
                {
                    Items = queryResult.Value
                };
            }
            else
            {
                result.Errors = queryResult.Errors;
            }

            return result;

        }

        public async Task<Result<AuthorSelectList>> SelectList()
        {
            var result = new Result<AuthorSelectList>();

            var queryResult = await _authorSelectListQuery.Execute();

            if (queryResult.IsSuccess)
            {
                result.Value = new AuthorSelectList
                {
                    Items = queryResult.Value
                };
            }
            else
            {
                result.Errors = queryResult.Errors;
            }

            return result;
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

    public class AuthorList
    {
        public IList<AuthorItem> Items { get; set; }
    }

    public class AuthorSelectList
    {
        public IList<AuthorSelectListItem> Items { get; set; }
    }
}
