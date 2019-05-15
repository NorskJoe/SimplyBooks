using SimplyBooks.Models;
using SimplyBooks.Repository.Commands.Interfaces.Nationalities;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace SimplyBooks.Repository.Commands.Concrete.Nationalities
{
    class AddNationalityCommand : IAddNationalityCommand
    {
        private SimplyBooksContext _context;

        public AddNationalityCommand(SimplyBooksContext context)
        {
            _context = context;
        }

        public async Task<HttpResponseMessage> AddNationality(Nationality nationality)
        {
            var response = new HttpResponseMessage();

            if (_context.Nationality.Any(x => x.Name == nationality.Name))
            {
                response.StatusCode = HttpStatusCode.Conflict;
            }

            _context.Nationality.Add(nationality);
            await _context.SaveChangesAsync();

            response.StatusCode = HttpStatusCode.Created;
            return response;
        }
    }
}
