using Microsoft.EntityFrameworkCore;
using SimplyBooks.Models;
using SimplyBooks.Models.ResultModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimplyBooks.Repository.Queries.Authors
{
    public interface IListAllAuthorsQuery
    {
        Task<Result<IList<Author>>> Execute();
    }
    class ListAllAuthorsQuery : IListAllAuthorsQuery
    {
        private readonly SimplyBooksContext _context;

        public ListAllAuthorsQuery(SimplyBooksContext context)
        {
            _context = context;
        }

        public async Task<Result<IList<Author>>> Execute()
        {
            Result<IList<Author>> result = new Result<IList<Author>>();

            try
            {
                result.Value = await _context.Author
                            .Include(b => b.Nationality)
                            .ToListAsync();
            }
            catch (Exception ex)
            {
                result.AddError($"Exception thrown ListAllAuthors:\n Message: {ex.Message}.\n Stacktrace: {ex.StackTrace}");
            }

            return result;
        }
    }
}
