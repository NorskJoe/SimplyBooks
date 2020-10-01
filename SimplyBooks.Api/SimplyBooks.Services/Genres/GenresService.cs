using SimplyBooks.Domain;
using SimplyBooks.Repository.Commands.Genres;
using SimplyBooks.Repository.Queries.Genres;
using System.Collections.Generic;
using System.Threading.Tasks;
using SimplyBooks.Domain.QueryModels;
using Microsoft.EntityFrameworkCore.Internal;
using System.Linq;
using Microsoft.Extensions.Localization;

namespace SimplyBooks.Services.Genres
{
    public interface IGenresService : IService
    {
        Task<Result<GenreSelectList>> SelectList();
        Task<Result> UpdateGenreAsync(Genre genre);
        Task<Result> AddGenreAsync(Genre genre);
    }

    public class GenresService : IGenresService
    {
        private readonly IAddGenreCommand _addGenreCommand;
        private readonly IUpdateGenreCommand _updateGenreCommand;
        private readonly IGenreSelectListQuery _genreSelectListQuery;
        private readonly IStringLocalizer<GenresService> _localizer;

        public GenresService(IAddGenreCommand addGenreCommand,
            IUpdateGenreCommand updateGenreCommand,
            IGenreSelectListQuery genreSelectListQuery,
            IStringLocalizer<GenresService> localizer)
        {
            _addGenreCommand = addGenreCommand;
            _updateGenreCommand = updateGenreCommand;
            _genreSelectListQuery = genreSelectListQuery;
            _localizer = localizer;
        }

        public async Task<Result<GenreSelectList>> SelectList()
        {
            var result = new Result<GenreSelectList>();

            var queryResult = await _genreSelectListQuery.Execute();

            if (!queryResult.Any())
            {
                result.AddWarning(_localizer["NoGenresSelectList"]);
            }
            else
            {
                result.Value = new GenreSelectList
                {
                    Items = queryResult
                };
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
