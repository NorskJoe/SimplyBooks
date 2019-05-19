using SimplyBooks.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimplyBooks.Repository.Queries.Books
{
    public interface IListBooksByAuthorNationalityQuery
    {
        Task<IList<Book>> Execute(int id);
    }

    class ListBooksByAuthorNationalityQuery : IListBooksByAuthorNationalityQuery
    {
        public Task<IList<Book>> Execute(int id)
        {
            throw new NotImplementedException();
        }
    }
}
