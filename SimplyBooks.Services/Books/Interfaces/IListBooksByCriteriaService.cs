using SimplyBooks.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimplyBooks.Services.Books.Interfaces
{
    public interface IListBooksByCriteriaService
    {
        Task<IList<Book>> ListBooksByAuthorAsync(int authorId);
        Task<IList<Book>> ListBooksByGenreAsync(int genreId);
        Task<IList<Book>> ListBooksByAuthorNationalityAsync(int nationalityId);
        Task<IList<Book>> ListBooksByYearReadAsync(DateTime yearRead);
        Task<IList<Book>> ListBooksByYearPublishedAsync(DateTime yearPublished);
    }
}
