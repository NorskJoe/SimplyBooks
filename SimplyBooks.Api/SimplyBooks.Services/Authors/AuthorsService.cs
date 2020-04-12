﻿using SimplyBooks.Models;
using SimplyBooks.Repository.Commands.Authors;
using SimplyBooks.Repository.Queries.Authors;
using System.Collections.Generic;
using System.Threading.Tasks;
using SimplyBooks.Models.QueryModels;
using System.Linq;
using Microsoft.Extensions.Localization;

namespace SimplyBooks.Services.Authors
{
    public interface IAuthorsService
    {
        Task<Result<PagedResult<AuthorListItem>>> ListAuthorsAsync(AuthorListCriteria criteria);
        Task<Result<AuthorSelectList>> SelectList();
        Task<Result> AddAuthorAsync(Author author);
        Task<Result> UpdateAuthorAsync(Author author);
    }

    public class AuthorsService : IAuthorsService
    {
        private readonly IAddAuthorCommand _addAuthorCommand;
        private readonly IUpdateAuthorCommand _updateAuthorCommand;
        private readonly IListAuthorsQuery _listAuthorsQuery;
        private readonly IAuthorSelectListQuery _authorSelectListQuery;
        private readonly IStringLocalizer<AuthorsService> _localiser;

        public AuthorsService(IAddAuthorCommand addAuthorCommand,
            IUpdateAuthorCommand updateAuthorCommand,
            IListAuthorsQuery listAuthorsQuery,
            IAuthorSelectListQuery authorSelectListQuery,
            IStringLocalizer<AuthorsService> localiser)
        {
            _listAuthorsQuery = listAuthorsQuery;
            _addAuthorCommand = addAuthorCommand;
            _updateAuthorCommand = updateAuthorCommand;
            _authorSelectListQuery = authorSelectListQuery;
            _localiser = localiser;
        }

        public async Task<Result<PagedResult<AuthorListItem>>> ListAuthorsAsync(AuthorListCriteria criteria)
        {
            var result = new Result<PagedResult<AuthorListItem>>();

            var queryResult = await _listAuthorsQuery.Execute(criteria);

            if (queryResult.IsSuccess)
            {
                var rowItems = queryResult.Value
                    .Skip(criteria.FirstRecord)
                    .Take(criteria.PageSize)
                    .ToList();

                result.Value = new PagedResult<AuthorListItem>
                {
                    Items = rowItems,
                    PageIndex = criteria.PageIndex,
                    Total = queryResult.Value.Count
                };

                if (queryResult.Value.Count == 0)
                {
                    result.Warnings.Add(_localiser["NoAuthorsFound"]);
                }
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

    public class AuthorSelectList
    {
        public IList<AuthorSelectListItem> Items { get; set; }
    }
}
