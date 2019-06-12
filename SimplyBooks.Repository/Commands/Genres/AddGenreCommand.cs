using SimplyBooks.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SimplyBooks.Repository.Commands.Genres
{
    public interface IAddGenreCommand
    {
        Task<HttpResponseMessage> AddGenre(Genre genre);
    }

    public class AddGenreCommand : IAddGenreCommand
    {
        public Task<HttpResponseMessage> AddGenre(Genre genre)
        {
            throw new NotImplementedException();
        }
    }
}
