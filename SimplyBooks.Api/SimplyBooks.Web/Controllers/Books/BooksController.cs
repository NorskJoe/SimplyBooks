using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimplyBooks.Domain;
using SimplyBooks.Domain.QueryModels;
using SimplyBooks.Repository.Commands.Books;
using SimplyBooks.Repository.Queries.Books;
using SimplyBooks.Services.Books;

namespace SimplyBooks.Web.Controllers.Books
{
    [Route("book")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBooksService _booksService;

        public BooksController(IBooksService booksService)
        {
            _booksService = booksService;
        }

        // GET: /book/list
        [HttpGet("list")]
        [ProducesResponseType(typeof(PagedResult<BookListItem>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ListAllBooks([FromQuery]BookListCriteria criteria)
        {
            var result = await _booksService.ListAllBooksAsync(criteria);
            return Ok(result);
        }

        // GET: /book/get/{bookId}
        [HttpGet("get/{bookId}")]
        [ProducesResponseType(typeof(BookItem), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetBook(int bookId)
        {
            var criteria = new BookItemCriteria
            {
                BookId = bookId
            };

            var result = await _booksService.GetBookAsync(criteria);
            return Ok(result);
        }

        // POST
        [HttpPost]
        [ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddBook([FromBody]Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _booksService.AddBookAsync(book);
            return Ok(result);
        }

        // PUT
        [HttpPut]
        [ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateBook([FromBody]Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _booksService.UpdateBookAsync(book);
            return Ok(result);
            
        }

        // DELETE
        [HttpDelete]
        [ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteBook(int bookId)
        {
            var criteria = new DeleteBookCriteria
            {
                BookId = bookId
            };
            var result = await _booksService.DeleteBookAsync(criteria);
            return Ok(result);
        }
    }
}
