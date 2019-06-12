using SimplyBooks.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimplyBooks.Repository.Queries.Books
{
    public interface IListBooksByYearPublishedQuery
    {
        Task<IList<Book>> Execute(DateTime year);

    }
    public class ListBooksByYearPublishedQuery : IListBooksByYearPublishedQuery
    {
        public Task<IList<Book>> Execute(DateTime year)
        {
            throw new NotImplementedException();
        }
    }
}
