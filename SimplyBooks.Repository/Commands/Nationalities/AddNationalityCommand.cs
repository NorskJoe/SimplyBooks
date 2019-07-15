using SimplyBooks.Models;
using SimplyBooks.Models.ResultModels;
using System;
using System.Threading.Tasks;

namespace SimplyBooks.Repository.Commands.Nationalities
{
    public interface IAddNationalityCommand
    {
        Task<Result> Execute(Nationality nationality);
    }

    public class AddNationalityCommand : IAddNationalityCommand
    {
        private SimplyBooksContext _context;

        public AddNationalityCommand(SimplyBooksContext context)
        {
            _context = context;
        }

        public async Task<Result> Execute(Nationality nationality)
        {
            throw new NotImplementedException();
        }
    }
}
