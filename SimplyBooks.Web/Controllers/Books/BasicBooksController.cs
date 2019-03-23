using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimplyBooks.Models;
using SimplyBooks.Services.Books.Interfaces;

namespace SimplyBooksApi.Controllers.Books
{
    [Route("v1/book")]
    [ApiController]
    public class BasicBooksController : ControllerBase
    {
        private readonly IBasicBooksService _booksService;

        public BasicBooksController(IBasicBooksService booksService)
        {
            _booksService = booksService;
        }

        // GET: v1/book/list
        [HttpGet("list")]
        [ProducesResponseType(typeof(IList<Book>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IList<Book>>> ListAllBooks()
        {
            var books = await _booksService.ListAllBooksAsync();

            if (books == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(books);
            }
        }

        // GET: v1/book/get/{id}
        [HttpGet("get{id}")]
        [ProducesResponseType(typeof(Book), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Book>> GetBook(int bookId)
        {
            try
            {
                var book = await _booksService.GetBookAsync(bookId);
                return Ok(book);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        // PUT: v1/book/update/{book}
        [HttpPut("update{book}")]
        [ProducesResponseType(typeof(Book), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> UpdateBook(Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                var updatedBook = await _booksService.UpdateBookAsync(book);
                return Ok(updatedBook);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        // POST: v1/book/add/{book}
        [HttpPost("add{book}")]
        [ProducesResponseType(typeof(Book), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> AddBook([FromBody]Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var newBook = await _booksService.AddBookAsync(book);
            return Ok(newBook);
        }

        // DELETE: v1/book/delete/{id}
        [HttpDelete("delete{id}")]
        [ProducesResponseType(typeof(Book), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteBook(int bookId)
        {
            try
            {
                var deletedBook = await _booksService.DeleteBookAsync(bookId);
                return Ok(deletedBook);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
