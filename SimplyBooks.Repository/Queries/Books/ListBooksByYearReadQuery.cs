using SimplyBooks.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimplyBooks.Repository.Queries.Books
{
    public interface IListBooksByYearReadQuery
    {
        Task<IList<Book>> Execute(DateTime year);
    }

    class ListBooksByYearReadQuery : IListBooksByYearReadQuery
    {
        public Task<IList<Book>> Execute(DateTime year)
        {
            throw new NotImplementedException();
        }
    }
}
