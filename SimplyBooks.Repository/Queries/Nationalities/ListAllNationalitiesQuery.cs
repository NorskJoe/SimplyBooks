using SimplyBooks.Models;
using SimplyBooks.Models.ResultModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimplyBooks.Repository.Queries.Nationalities
{
    public interface IListAllNationalitiesQuery
    {
        Task<Result<IList<Nationality>>> Execute();
    }

    public class ListAllNationalitiesQuery : IListAllNationalitiesQuery
    {
        public async Task<Result<IList<Nationality>>> Execute()
        {
            throw new NotImplementedException();
        }
    }
}
