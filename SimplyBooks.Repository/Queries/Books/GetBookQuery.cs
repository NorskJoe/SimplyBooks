using Microsoft.EntityFrameworkCore;
using SimplyBooks.Models;
using SimplyBooks.Models.ResultModels;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SimplyBooks.Repository.Queries.Books
{
    public interface IGetBookQuery
    {
        Task<Result<Book>> Execute(int id);
    }

    public class GetBookQuery : IGetBookQuery
    {
        private readonly SimplyBooksContext _context;

        public GetBookQuery(SimplyBooksContext context)
        {
            _context = context;
        }

        public async Task<Result<Book>> Execute(int id)
        {
            Result<Book> result = new Result<Book>();

            try
            {
                result.Value = await _context.Book
                            .Include(b => b.Author)
                                .ThenInclude(a => a.Nationality)
                            .Include(b => b.Genre)
                            .Where(b => b.BookId == id)
                            .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                result.AddError($"Exception thrown GetBook:\n Message: {ex.Message}.\n Stacktrace: {ex.StackTrace}");
            }

            return result;
        }
    }
}
