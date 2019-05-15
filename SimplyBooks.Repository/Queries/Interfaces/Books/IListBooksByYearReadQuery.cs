using SimplyBooks.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimplyBooks.Repository.Queries.Interfaces.Books
{
    public interface IListBooksByYearReadQuery
    {
        Task<IList<Book>> Execute(DateTime year);
    }
}
