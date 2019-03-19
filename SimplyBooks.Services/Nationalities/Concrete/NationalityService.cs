using SimplyBooks.Models;
using SimplyBooks.Services.Nationalities.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
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
