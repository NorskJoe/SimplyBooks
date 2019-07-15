using SimplyBooks.Models;
using SimplyBooks.Models.ResultModels;
using System;
using System.Threading.Tasks;

namespace SimplyBooks.Repository.Commands.Nationalities
{
    public interface IUpdateNationalityCommand
    {
        Task<Result> Execute(Nationality nationality);
    }

    public class UpdateNationalityCommand : IUpdateNationalityCommand
    {
        public async Task<Result> Execute(Nationality nationality)
        {
            throw new NotImplementedException();
        }
    }
}
