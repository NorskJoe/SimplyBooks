using SimplyBooks.Models;
using SimplyBooks.Services.Books.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SimplyBooks.Services.Books.Concrete
{
    class BasicBooksService : IBasicBooksService
    {
        public Task<HttpResponseMessage> AddBookAsync(Book book)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> DeleteBookAsync(int bookId)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> GetBookAsync(int bookId)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> ListAllBooksAsync()
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> UpdateBookAsync(Book book)
        {
            throw new NotImplementedException();
        }
    }
}
