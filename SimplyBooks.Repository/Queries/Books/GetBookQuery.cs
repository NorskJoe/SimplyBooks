using SimplyBooks.Models;
using System;
using System.Threading.Tasks;

namespace SimplyBooks.Repository.Queries.Books
{
    public interface IGetBookQuery
    {
        Task<Book> Execute(int id);
    }

    class GetBookQuery : IGetBookQuery
    {
        public Task<Book> Execute(int id)
        {
            throw new NotImplementedException();
        }
    }
}
