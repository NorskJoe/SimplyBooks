using SimplyBooks.Models;
using SimplyBooks.Models.ResultModels;
using System;
using System.Threading.Tasks;

namespace SimplyBooks.Repository.Commands.Authors
{
    public interface IAddAuthorCommand
    {
        Task<Result> Execute(Author author);
    }

    public class AddAuthorCommand : IAddAuthorCommand
    {
        public Task<Result> Execute(Author author)
        {
            throw new NotImplementedException();
        }
    }
}
