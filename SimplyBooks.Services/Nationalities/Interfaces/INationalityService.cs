using SimplyBooks.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SimplyBooks.Services.Nationalities.Interfaces
{
    interface INationalityService
    {
        Task<HttpResponseMessage> UpdateNationalityAsync(Nationality nationality);
        Task<HttpResponseMessage> AddNationalityAsync(Nationality nationality);
    }
}
