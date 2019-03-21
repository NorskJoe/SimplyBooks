using SimplyBooks.Services.Books.Interfaces;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SimplyBooks.Services.Books.Concrete
{
    class ListBooksByCriteriaService : IListBooksByCriteriaService
    {
        public Task<HttpResponseMessage> ListBooksByAuthorAsync(int authorId)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> ListBooksByAuthorNationalityAsync(int nationalityId)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> ListBooksByGenreAsync(int genreId)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> ListBooksByYearPublishedAsync(DateTime yearPublished)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> ListBooksByYearReadAsync(DateTime yearRead)
        {
            throw new NotImplementedException();
        }
    }
}
