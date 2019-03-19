using SimplyBooks.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SimplyBooks.Services.Authors.Interfaces
{
    interface IAuthorsService
    {
        Task<HttpResponseMessage> UpdateAuthor(Author author);
        Task<HttpResponseMessage> AddAuthor(Author author);
    }
}
