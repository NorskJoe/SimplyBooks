using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SimplyBooks.Models;
using SimplyBooks.Models.Dtos;
using SimplyBooks.Services.Books;

namespace SimplyBooksApi.Controllers.Books
{
    [Route("book")]
    [ApiController]
    public class BasicBooksController : ControllerBase
    {
        private readonly IBasicBooksService _booksService;
        private readonly IMapper _mapper;

        public BasicBooksController(IBasicBooksService booksService,
            IMapper mapper)
        {
            _booksService = booksService;
            _mapper = mapper;
        }

        // GET: /book/list
        [HttpGet("list")]
        [ProducesResponseType(typeof(IList<Book>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ListAllBooks()
        {
            var result = await _booksService.ListAllBooksAsync();
            return Ok(result);
        }

        // GET: /book/get/{bookId}
        [HttpGet("get/{bookId}")]
        [ProducesResponseType(typeof(Book), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetBook(int bookId)
        {
            var result = await _booksService.GetBookAsync(bookId);
            return Ok(result);
        }

        // POST: /book/add/
        [HttpPost("add")]
        [ProducesResponseType(typeof(Book), StatusCodes.Status200OK)]
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

        // PUT: /book/update/{book}
        [HttpPut("update")]
        [ProducesResponseType(typeof(Book), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateBook([FromBody]BookDto book)
        {
            Book toUpdate = _mapper.Map<Book>(book);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _booksService.UpdateBookAsync(toUpdate);
            return Ok(result);
            
        }

        // DELETE: /book/delete/{bookId}
        [HttpDelete("delete/{bookId}")]
        [ProducesResponseType(typeof(Book), StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteBook(int bookId)
        {
            var result = await _booksService.DeleteBookAsync(bookId);
            return Ok(result);
        }
    }
}
