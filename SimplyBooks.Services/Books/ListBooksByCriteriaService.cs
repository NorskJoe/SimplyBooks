using SimplyBooks.Models;
using SimplyBooks.Models.Exceptions;
using SimplyBooks.Repository.Queries.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimplyBooks.Services.Books
{
    public interface IListBooksByCriteriaService
    {
        Task<IList<Book>> ListBooksByAuthorAsync(int authorId);
        Task<IList<Book>> ListBooksByGenreAsync(int genreId);
        Task<IList<Book>> ListBooksByAuthorNationalityAsync(int nationalityId);
        Task<IList<Book>> ListBooksByYearReadAsync(DateTime yearRead);
        Task<IList<Book>> ListBooksByYearPublishedAsync(DateTime yearPublished);
    }

    public class ListBooksByCriteriaService : IListBooksByCriteriaService
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

        public async Task<IList<Book>> ListBooksByAuthorAsync(int authorId)
        {
            var response = await _listByAuthorQuery.Execute(authorId);

            if (!response.Any())
            {
                throw new EntityNotFoundException(authorId, typeof(Author).Name);
            }
            return response;
        }

        public async Task<IList<Book>> ListBooksByGenreAsync(int genreId)
        {
            var response = await _listByGenreQuery.Execute(genreId);

            if (!response.Any())
            {
                throw new EntityNotFoundException(genreId, typeof(Genre).Name);
            }
            return response;
        }

        public async Task<IList<Book>> ListBooksByAuthorNationalityAsync(int nationalityId)
        {
            var response = await _listByAuthorNationalityQuery.Execute(nationalityId);

            if (!response.Any())
            {
                throw new EntityNotFoundException(nationalityId, typeof(Nationality).Name);
            }
            return response;
        }


        public async Task<IList<Book>> ListBooksByYearPublishedAsync(DateTime yearPublished)
        {
            var response = await _listByYearPublishedQuery.Execute(yearPublished);
            if (!response.Any())
            {
                throw new EntityNotFoundException(yearPublished, typeof(Book).Name);
            }
            return response;
        }

        public async Task<IList<Book>> ListBooksByYearReadAsync(DateTime yearRead)
        {
            var response = await _listByYearReadQuery.Execute(yearRead);
            if (!response.Any())
            {
                throw new EntityNotFoundException(yearRead, typeof(Book).Name);
            }
            return response;
        }
    }
}
