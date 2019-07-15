using SimplyBooks.Models;
using SimplyBooks.Models.ResultModels;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SimplyBooks.Repository.Commands.Authors
{
    public interface IUpdateAuthorCommand
    {
        Task<Result> Execute(Author author);
    }

    public class UpdateAuthorCommand : IUpdateAuthorCommand
    {
        public Task<Result> Execute(Author author)
        {
            throw new NotImplementedException();
        }
    }
}
