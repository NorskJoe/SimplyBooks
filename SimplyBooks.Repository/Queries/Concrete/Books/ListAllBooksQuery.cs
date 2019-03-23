using SimplyBooks.Models;
using SimplyBooks.Repository.Queries.Interfaces.Books;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimplyBooks.Repository.Queries.Concrete.Books
{
    class ListAllBooksQuery : IListAllBooksQuery
    {
        public Task<IList<Book>> Execute()
        {
            throw new NotImplementedException();
        }
    }
}
