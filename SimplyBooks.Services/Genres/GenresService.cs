using SimplyBooks.Models;
using SimplyBooks.Models.Exceptions;
using SimplyBooks.Repository.Commands.Genres;
using System.Net.Http;
using System.Threading.Tasks;

namespace SimplyBooks.Services.Genres
{
    public interface IGenresService
    {
        Task<HttpResponseMessage> UpdateGenreAsync(Genre genre);
        Task<HttpResponseMessage> AddGenreAsync(Genre genre);
    }

    class GenresService : IGenresService
    {
        private readonly IAddGenreCommand _addGenreCommand;
        private readonly IUpdateGenreCommand _updateGenreCommand;

        public GenresService(IAddGenreCommand addGenreCommand,
            IUpdateGenreCommand updateGenreCommand)
        {
            _addGenreCommand = addGenreCommand;
            _updateGenreCommand = updateGenreCommand;
        }

        public async Task<HttpResponseMessage> AddGenreAsync(Genre genre)
        {
            var response = await _addGenreCommand.AddGenre(genre);

            if (response.IsSuccessStatusCode)
            {
                return response;
            }
            else
            {
                throw new EntityAlreadyExistsException(genre.Name);
            }
        }

        public async Task<HttpResponseMessage> UpdateGenreAsync(Genre genre)
        {
            var response = await _updateGenreCommand.UpdateGenre(genre);

            if (response.IsSuccessStatusCode)
            {
                return response;
            }
            else
            {
                throw new EntityNotFoundException(genre.Name);
            }
        }
    }
}
