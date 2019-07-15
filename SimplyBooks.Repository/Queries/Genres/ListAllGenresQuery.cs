using SimplyBooks.Models;
using SimplyBooks.Models.ResultModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimplyBooks.Repository.Queries.Genres
{
    public interface IListAllGenresQuery
    {
        Task<Result<IList<Genre>>> Execute();
    }

    public class ListAllGenresQuery : IListAllGenresQuery
    {
        public Task<Result<IList<Genre>>> Execute()
        {
            throw new NotImplementedException();
        }
    }
}
