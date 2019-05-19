using SimplyBooks.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimplyBooks.Repository.Queries.Books
{
    public interface IListAllBooksQuery
    {
        Task<IList<Book>> Execute();
    }

    class ListAllBooksQuery : IListAllBooksQuery
    {
        public Task<IList<Book>> Execute()
        {
            throw new NotImplementedException();
        }
    }
}
