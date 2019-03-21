using SimplyBooks.Models;
using SimplyBooks.Services.Authors.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SimplyBooks.Services.Authors.Concrete
{
    class AuthorsService : IAuthorsService
    {
        public Task<HttpResponseMessage> AddAuthorAsync(Author author)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> UpdateAuthorAsync(Author author)
        {
            throw new NotImplementedException();
        }
    }
}
