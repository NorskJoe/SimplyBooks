using SimplyBooks.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SimplyBooks.Repository.Commands.Genres
{
    public interface IUpdateGenreCommand
    {
        Task<HttpResponseMessage> UpdateGenre(Genre genre);
    }

    class UpdateGenreCommand : IUpdateGenreCommand
    {
        public Task<HttpResponseMessage> UpdateGenre(Genre genre)
        {
            throw new NotImplementedException();
        }
    }
}
