using SimplyBooks.Models;
using SimplyBooks.Repository.Queries.Interfaces.Books;
using SimplyBooks.Services.Books.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimplyBooks.Services.Books.Concrete
{
    class ListBooksByCriteriaService : IListBooksByCriteriaService
    {
        private readonly IListBooksByAuthorNationalityQuery _listByAuthorNationalityQuery;
        private readonly IListBooksByAuthorQuery _listByAuthorQuery;
        private readonly IListBooksByGenreQuery _listByGenreQuery;
        private readonly IListBooksByYearPublishedQuery _listByYearPublishedQuery;
        private readonly IListBooksByYearReadQuery _listByYearReadQuery;

        public ListBooksByCriteriaService(IListBooksByAuthorNationalityQuery listByAuthorNationalityQuery,
            IListBooksByAuthorQuery listByAuthorQuery,
            IListBooksByGenreQuery listByGenreQuery,
            IListBooksByYearPublishedQuery listByYearPublishedQuery,
            IListBooksByYearReadQuery listByYearReadQuery)
        {
            _listByAuthorNationalityQuery = listByAuthorNationalityQuery;
            _listByAuthorQuery = listByAuthorQuery;
            _listByGenreQuery = listByGenreQuery;
            _listByYearPublishedQuery = listByYearPublishedQuery;
            _listByYearReadQuery = listByYearReadQuery;
        }

        public async Task<IList<Book>> ListBooksByAuthorNationalityAsync(int nationalityId)
        {
            return await _listByAuthorNationalityQuery.Execute(nationalityId);
        }

        public async Task<IList<Book>> ListBooksByAuthorAsync(int authorId)
        {
            return await _listByAuthorQuery.Execute(authorId);
        }

        public async Task<IList<Book>> ListBooksByGenreAsync(int genreId)
        {
            return await _listByGenreQuery.Execute(genreId);
        }

        public async Task<IList<Book>> ListBooksByYearPublishedAsync(DateTime yearPublished)
        {
            return await _listByYearPublishedQuery.Execute(yearPublished);
        }

        public async Task<IList<Book>> ListBooksByYearReadAsync(DateTime yearRead)
        {
            return await _listByYearReadQuery.Execute(yearRead);
        }
    }
}
