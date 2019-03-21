using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SimplyBooks.Services.Books.Interfaces
{
    public interface IListBooksByCriteriaService
    {
        Task<HttpResponseMessage> ListBooksByAuthorAsync(int authorId);
        Task<HttpResponseMessage> ListBooksByGenreAsync(int genreId);
        Task<HttpResponseMessage> ListBooksByAuthorNationalityAsync(int nationalityId);
        Task<HttpResponseMessage> ListBooksByYearReadAsync(DateTime yearRead);
        Task<HttpResponseMessage> ListBooksByYearPublishedAsync(DateTime yearPublished);
    }
}
