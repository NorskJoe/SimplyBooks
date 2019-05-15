using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimplyBooks.Models;
using SimplyBooks.Models.Exceptions;
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
        public async Task<IActionResult> ListAllBooks()
        {
            try
            {
                var books = await _booksService.ListAllBooksAsync();
                return Ok(books);
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }
        }

        // GET: v1/book/get/{id}
        [HttpGet("get{id}")]
        [ProducesResponseType(typeof(Book), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetBook(int bookId)
        {
            try
            {
                var book = await _booksService.GetBookAsync(bookId);
                return Ok(book);
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }
        }

        // POST: v1/book/add/{book}
        [HttpPost("add{book}")]
        [ProducesResponseType(typeof(Book), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> AddBook([FromBody]Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _booksService.AddBookAsync(book);
                return Ok(book);
            }
            catch (EntityAlreadyExistsException ex)
            {
                return Conflict(ex.Message);
            }
        }

        // PUT: v1/book/update/{book}
        [HttpPut("update{book}")]
        [ProducesResponseType(typeof(Book), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateBook(Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _booksService.UpdateBookAsync(book);
                return Ok(book);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // DELETE: v1/book/delete/{id}
        [HttpDelete("delete{id}")]
        [ProducesResponseType(typeof(Book), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteBook(int bookId)
        {
            try
            {
                await _booksService.DeleteBookAsync(bookId);
                return Ok();
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
