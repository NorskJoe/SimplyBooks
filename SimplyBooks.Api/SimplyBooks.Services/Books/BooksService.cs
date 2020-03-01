﻿using Microsoft.Extensions.Localization;
using SimplyBooks.Models;
using SimplyBooks.Models.ResultModels;
using SimplyBooks.Repository.Commands.Books;
using SimplyBooks.Repository.Queries.Books;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimplyBooks.Services.Books
{
    public interface IBooksService
    {
        Task<Result<BookList>> ListAllBooksAsync(BookListCriteria criteria);
        Task<Result<BookItem>> GetBookAsync(int bookId);
        Task<Result> AddBookAsync(Book book);
        Task<Result> UpdateBookAsync(Book book);
        Task<Result> DeleteBookAsync(int bookId);
    }

    public class BooksService : IBooksService
    {
        private readonly IAddBookCommand _addBookCommand;
        private readonly IUpdateBookCommand _updateBookCommand;
        private readonly IDeleteBookCommand _deleteBookCommand;
        private readonly IGetBookQuery _getBookQuery;
        private readonly IListAllBooksQuery _listBooksQuery;
        private readonly IStringLocalizer<BooksService> _localiser;

        public BooksService(IAddBookCommand addBookCommand,
            IUpdateBookCommand updateBookCommand,
            IDeleteBookCommand deleteBookCommand,
            IGetBookQuery getBookQuery,
            IListAllBooksQuery listBooksQuery,
            IStringLocalizer<BooksService> localiser)
        {
            _addBookCommand = addBookCommand;
            _updateBookCommand = updateBookCommand;
            _deleteBookCommand = deleteBookCommand;
            _getBookQuery = getBookQuery;
            _listBooksQuery = listBooksQuery;
            _localiser = localiser;
        }

        public async Task<Result<BookList>> ListAllBooksAsync(BookListCriteria criteria)
        {
            var result = new Result<BookList>();

            var queryResult = await _listBooksQuery.Execute(criteria);

            if (queryResult.IsSuccess)
            {
                result.Value = new BookList
                {
                    Items = queryResult.Value
                };

                if (queryResult.Value.Count == 0)
                {
                    result.Warnings.Add(_localiser["NoBooksFound"]);
                }
            }
            else
            {
                result.Errors = queryResult.Errors;
            }

            return result;
        }

        public async Task<Result<BookItem>> GetBookAsync(int bookId)
        {
            return await _getBookQuery.Execute(bookId);
        }

        public async Task<Result> AddBookAsync(Book book)
        {
            return await _addBookCommand.Execute(book);
        }

        public async Task<Result> UpdateBookAsync(Book book)
        {
            return await _updateBookCommand.Execute(book);
        }

        public async Task<Result> DeleteBookAsync(int bookId)
        {
            return await _deleteBookCommand.Execute(bookId);
        }
    }

    public class BookList
    {
        public IList<BookListItem> Items { get; set; }
    }
}
