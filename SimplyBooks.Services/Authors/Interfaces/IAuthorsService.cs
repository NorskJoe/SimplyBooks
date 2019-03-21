using SimplyBooks.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SimplyBooks.Services.Authors.Interfaces
{
    public interface IAuthorsService
    {
        Task<HttpResponseMessage> UpdateAuthorAsync(Author author);
        Task<HttpResponseMessage> AddAuthorAsync(Author author);
    }
}
