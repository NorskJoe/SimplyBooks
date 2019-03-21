using SimplyBooks.Models;
using SimplyBooks.Services.Nationalities.Interfaces;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SimplyBooks.Services.Nationalities.Concrete
{
    class NationalityService : INationalityService
    {
        public Task<HttpResponseMessage> AddNationalityAsync(Nationality nationality)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> UpdateNationalityAsync(Nationality nationality)
        {
            throw new NotImplementedException();
        }
    }
}
