using SimplyBooks.Models;
using SimplyBooks.Repository.Commands.Genres;
using SimplyBooks.Repository.Queries.Genres;
using System.Collections.Generic;
using System.Threading.Tasks;
using SimplyBooks.Models.QueryModels;

namespace SimplyBooks.Services.Genres
{
    public interface IGenresService
    {
        Task<Result<IList<Genre>>> ListAllGenresAsync();
        Task<Result<GenreSelectList>> SelectList();
        Task<Result> UpdateGenreAsync(Genre genre);
        Task<Result> AddGenreAsync(Genre genre);
    }

    public class GenresService : IGenresService
    {
        private readonly IAddGenreCommand _addGenreCommand;
        private readonly IUpdateGenreCommand _updateGenreCommand;
        private readonly IListAllGenresQuery _listAllGenresQuery;
        private readonly IGenreSelectListQuery _genreSelectListQuery;

        public GenresService(IAddGenreCommand addGenreCommand,
            IUpdateGenreCommand updateGenreCommand,
            IListAllGenresQuery listAllGenresQuery,
            IGenreSelectListQuery genreSelectListQuery)
        {
            _addGenreCommand = addGenreCommand;
            _updateGenreCommand = updateGenreCommand;
            _listAllGenresQuery = listAllGenresQuery;
            _genreSelectListQuery = genreSelectListQuery;
        }

        public async Task<Result<IList<Genre>>> ListAllGenresAsync()
        {
            return await _listAllGenresQuery.Execute();
        }

        public async Task<Result<GenreSelectList>> SelectList()
        {
            var result = new Result<GenreSelectList>();

            var queryResult = await _genreSelectListQuery.Execute();

            if (queryResult.IsSuccess)
            {
                result.Value = new GenreSelectList
                {
                    Items = queryResult.Value
                };
            }
            else
            {
                result.Errors = queryResult.Errors;
            }

            return result;
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

    public class GenreSelectList
    {
        public IList<GenreSelectListItem> Items { get; set; }
    }
}
