using SimplyBooks.Models;
using SimplyBooks.Repository.Commands.Interfaces.Genres;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SimplyBooks.Repository.Commands.Concrete.Genres
{
    class UpdateGenreCommand : IUpdateGenreCommand
    {
        public Task<HttpResponseMessage> UpdateGenre(Genre genre)
        {
            throw new NotImplementedException();
        }
    }
}
