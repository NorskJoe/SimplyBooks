using SimplyBooks.Models;
using SimplyBooks.Services.Genres.Interfaces;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SimplyBooks.Services.Genres.Concrete
{
    class GenresService : IGenresService
    {
        public Task<HttpResponseMessage> AddGenreAsync(Genre genre)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> UpdateGenreAsync(Genre genre)
        {
            throw new NotImplementedException();
        }
    }
}
