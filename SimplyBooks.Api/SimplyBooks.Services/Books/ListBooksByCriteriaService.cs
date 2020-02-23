using SimplyBooks.Models;
using SimplyBooks.Models.ResultModels;
using SimplyBooks.Repository.Queries.Books;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimplyBooks.Services.Books
{
    public interface IListBooksByCriteriaService
    {
        Task<Result<IList<Book>>> ListBooksByAuthorAsync(int authorId);
        Task<Result<IList<Book>>> ListBooksByGenreAsync(int genreId);
        Task<Result<IList<Book>>> ListBooksByAuthorNationalityAsync(int nationalityId);
        Task<Result<IList<Book>>> ListBooksByYearReadAsync(DateTime yearRead);
        Task<Result<IList<Book>>> ListBooksByYearPublishedAsync(DateTime yearPublished);
    }

    public class ListBooksByCriteriaService : IListBooksByCriteriaService
    {
        private readonly IListBooksByAuthorNationalityQuery _listByAuthorNationalityQuery;
        private readonly IListBooksByAuthorQuery _listByAuthorQuery;
        private readonly IListBooksByGenreQuery _listByGenreQuery;
        private readonly IListBooksByYearPublishedQuery _listByYearPublishedQuery;
        private readonly IListBooksByDateReadQuery _listByDateReadQuery;

        public ListBooksByCriteriaService(IListBooksByAuthorNationalityQuery listByAuthorNationalityQuery,
            IListBooksByAuthorQuery listByAuthorQuery,
            IListBooksByGenreQuery listByGenreQuery,
            IListBooksByYearPublishedQuery listByYearPublishedQuery,
            IListBooksByDateReadQuery listByDateReadQuery)
        {
            _listByAuthorNationalityQuery = listByAuthorNationalityQuery;
            _listByAuthorQuery = listByAuthorQuery;
            _listByGenreQuery = listByGenreQuery;
            _listByYearPublishedQuery = listByYearPublishedQuery;
            _listByDateReadQuery = listByDateReadQuery;
        }

        public async Task<Result<IList<Book>>> ListBooksByAuthorAsync(int authorId)
        {
            return await _listByAuthorQuery.Execute(authorId);
        }

        public async Task<Result<IList<Book>>> ListBooksByGenreAsync(int genreId)
        {
            return await _listByGenreQuery.Execute(genreId);
        }

        public async Task<Result<IList<Book>>> ListBooksByAuthorNationalityAsync(int nationalityId)
        {
            return await _listByAuthorNationalityQuery.Execute(nationalityId);
        }

        public async Task<Result<IList<Book>>> ListBooksByYearReadAsync(DateTime yearRead)
        {
            return await _listByDateReadQuery.Execute(yearRead);
        }

        public async Task<Result<IList<Book>>> ListBooksByYearPublishedAsync(DateTime yearPublished)
        {
            var temp = await _listByYearPublishedQuery.Execute(yearPublished);
            return temp;
        }
    }
}
