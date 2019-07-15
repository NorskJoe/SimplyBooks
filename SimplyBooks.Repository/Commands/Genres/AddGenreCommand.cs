using SimplyBooks.Models;
using SimplyBooks.Models.ResultModels;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SimplyBooks.Repository.Commands.Genres
{
    public interface IAddGenreCommand
    {
        Task<Result> Execute(Genre genre);
    }

    public class AddGenreCommand : IAddGenreCommand
    {
        public Task<Result> Execute(Genre genre)
        {
            throw new NotImplementedException();
        }
    }
}
