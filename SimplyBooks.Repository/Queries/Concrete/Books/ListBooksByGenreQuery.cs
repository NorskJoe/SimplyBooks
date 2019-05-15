using SimplyBooks.Models;
using SimplyBooks.Repository.Queries.Interfaces.Books;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimplyBooks.Repository.Queries.Concrete.Books
{
    class ListBooksByGenreQuery : IListBooksByGenreQuery
    {
        public Task<IList<Book>> Execute(int id)
        {
            throw new NotImplementedException();
        }
    }
}
