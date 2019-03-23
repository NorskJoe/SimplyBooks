using SimplyBooks.Models;
using SimplyBooks.Repository.Queries.Interfaces.Books;
using System;
using System.Threading.Tasks;

namespace SimplyBooks.Repository.Queries.Concrete.Books
{
    class GetBookQuery : IGetBookQuery
    {
        public Task<Book> Execute(int id)
        {
            throw new NotImplementedException();
        }
    }
}
