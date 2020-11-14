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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Result<PagedResult<BookListItem>>>> ListAllBooks([FromQuery]BookListCriteria criteria)
        {
            if (!ModelState.IsValid || criteria == null)
            {
                return BadRequest();
            }
            var result = await _booksService.ListAllBooksAsync(criteria);
            return Ok(result);
        }

        // GET: /book/get/{bookId}
        [HttpGet("get/{bookId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Result<BookItem>>> GetBook(int bookId)
        {
            if (bookId >= 0)
            {
                return BadRequest();
            }

            var criteria = new BookItemCriteria
            {
                BookId = bookId
            };

            var result = await _booksService.GetBookAsync(criteria);
            return Ok(result);
        }

        // POST
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Result>> AddBook([FromBody]Book book)
        {
            if (!ModelState.IsValid || book == null)
            {
                return BadRequest(ModelState);
            }

            var result = await _booksService.AddBookAsync(book);
            return Ok(result);
        }

        // PUT
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Result>> UpdateBook([FromBody]Book book)
        {
            if (!ModelState.IsValid || book == null)
            {
                return BadRequest(ModelState);
            }

            var result = await _booksService.UpdateBookAsync(book);
            return Ok(result);
            
        }

        // DELETE
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Result>> DeleteBook(int bookId)
        {
            if (bookId <= 0)
            {
                return BadRequest();
            }
            
            var criteria = new DeleteBookCriteria
            {
                BookId = bookId
            };
            var result = await _booksService.DeleteBookAsync(criteria);
            return Ok(result);
        }
    }
}
