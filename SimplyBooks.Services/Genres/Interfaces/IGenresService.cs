using SimplyBooks.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SimplyBooks.Services.Genres.Interfaces
{
    interface IGenresService
    {
        Task<HttpResponseMessage> UpdateGenreAsync(Genre genre);
        Task<HttpResponseMessage> AddGenreAsync(Genre genre);
    }
}
