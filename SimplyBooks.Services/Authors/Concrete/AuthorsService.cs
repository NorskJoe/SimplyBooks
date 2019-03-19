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
        public Task<HttpResponseMessage> AddAuthor(Author author)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> UpdateAuthor(Author author)
        {
            throw new NotImplementedException();
        }
    }
}
