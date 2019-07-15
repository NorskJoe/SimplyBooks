using SimplyBooks.Models;
using SimplyBooks.Models.ResultModels;
using System;
using System.Threading.Tasks;

namespace SimplyBooks.Repository.Commands.Genres
{
    public interface IUpdateGenreCommand
    {
        Task<Result> Execute(Genre genre);
    }

    public class UpdateGenreCommand : IUpdateGenreCommand
    {
        public Task<Result> Execute(Genre genre)
        {
            throw new NotImplementedException();
        }
    }
}
