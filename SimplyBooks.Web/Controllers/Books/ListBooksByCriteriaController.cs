using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimplyBooks.Models;
using SimplyBooks.Models.Exceptions;
using SimplyBooks.Services.Books;

namespace SimplyBooks.Web.Controllers.Books
{
    [Route("booklists")]
    [ApiController]
    public class ListBooksByCriteriaController : Controller
    {
        private readonly IListBooksByCriteriaService _listBooksService;

        public ListBooksByCriteriaController(IListBooksByCriteriaService listBooksService)
        {
            _listBooksService = listBooksService;
        }

        // GET: /booklists/by-author/{authorId}
        [HttpGet("by-author/{authorId}")]
        [ProducesResponseType(typeof(IList<Book>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ListBooksByAuthor(int authorId)
        {
            try
            {
                var books = await _listBooksService.ListBooksByAuthorAsync(authorId);
                return Ok(books);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // GET: /booklists/by-genre/{genreId}
        [HttpGet("by-genre/{genreId}")]
        [ProducesResponseType(typeof(IList<Book>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ListBooksByGenre(int genreId)
        {
            try
            {
                var books = await _listBooksService.ListBooksByGenreAsync(genreId);
                return Ok(books);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // GET: /booklists/by-nationality/{nationalityId}
        [HttpGet("by-nationality/{nationalityId}")]
        [ProducesResponseType(typeof(IList<Book>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ListBooksByAuthorNationality(int nationalityId)
        {
            try
            {
                var books = await _listBooksService.ListBooksByAuthorNationalityAsync(nationalityId);
                return Ok(books);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // GET: /booklists/by-yearread/{yearRead}
        [HttpGet("by-yearread/{yearRead}")]
        [ProducesResponseType(typeof(IList<Book>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ListBooksByYearRead(string yearRead)
        {
            DateTime year = new DateTime(Convert.ToInt32(yearRead), 1, 1);
            try
            {
                var books = await _listBooksService.ListBooksByYearReadAsync(year);
                return Ok(books);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // GET: /booklists/by-yearpublished/{yearPublished}
        [HttpGet("by-yearpublished/{yearPublished}")]
        [ProducesResponseType(typeof(IList<Book>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ListBooksByYearPublished(string yearPublished)
        {
            DateTime year = new DateTime(Convert.ToInt32(yearPublished), 1, 1);
            try
            {
                var books = await _listBooksService.ListBooksByYearPublishedAsync(year);
                return Ok(books);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}