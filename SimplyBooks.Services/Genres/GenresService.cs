using SimplyBooks.Models;
using SimplyBooks.Models.Exceptions;
using SimplyBooks.Models.ResultModels;
using SimplyBooks.Repository.Commands.Genres;
using SimplyBooks.Repository.Queries.Genres;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace SimplyBooks.Services.Genres
{
    public interface IGenresService
    {
        Task<Result<IList<Genre>>> ListAllGenresAsync();
        Task<Result> UpdateGenreAsync(Genre genre);
        Task<Result> AddGenreAsync(Genre genre);
    }

    public class GenresService : IGenresService
    {
        private readonly IAddGenreCommand _addGenreCommand;
        private readonly IUpdateGenreCommand _updateGenreCommand;
        private readonly IListAllGenresQuery _listAllGenresQuery;

        public GenresService(IAddGenreCommand addGenreCommand,
            IUpdateGenreCommand updateGenreCommand,
            IListAllGenresQuery listAllGenresQuery)
        {
            _addGenreCommand = addGenreCommand;
            _updateGenreCommand = updateGenreCommand;
            _listAllGenresQuery = listAllGenresQuery;
        }

        public async Task<Result<IList<Genre>>> ListAllGenresAsync()
        {
            return await _listAllGenresQuery.Execute();
        }

        public async Task<Result> AddGenreAsync(Genre genre)
        {
            return await _addGenreCommand.Execute(genre);
        }

        public async Task<Result> UpdateGenreAsync(Genre genre)
        {
            return await _updateGenreCommand.Execute(genre);
        }
    }
}
