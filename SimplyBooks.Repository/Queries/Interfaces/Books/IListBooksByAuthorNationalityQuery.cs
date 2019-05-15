using SimplyBooks.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimplyBooks.Repository.Queries.Interfaces.Books
{
    public interface IListBooksByAuthorNationalityQuery
    {
        Task<IList<Book>> Execute(int id);
    }
}
