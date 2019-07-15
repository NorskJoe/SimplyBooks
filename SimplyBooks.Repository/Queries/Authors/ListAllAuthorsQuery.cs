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
        Task<Result<List<Author>>> Execute();
    }
    class ListAllAuthorsQuery : IListAllAuthorsQuery
    {
        private readonly SimplyBooksContext _context;

        public ListAllAuthorsQuery(SimplyBooksContext context)
        {
            _context = context;
        }

        public async Task<Result<List<Author>>> Execute()
        {
            Result<List<Author>> result = new Result<List<Author>>();

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
