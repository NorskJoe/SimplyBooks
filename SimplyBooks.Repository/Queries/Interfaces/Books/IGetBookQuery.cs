using SimplyBooks.Models;
using System.Threading.Tasks;

namespace SimplyBooks.Repository.Queries.Interfaces.Books
{
    public interface IGetBookQuery
    {
        Task<Book> Execute(int id);
    }
}
