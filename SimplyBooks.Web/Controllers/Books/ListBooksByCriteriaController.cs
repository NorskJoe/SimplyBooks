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
    [Route("v1/booklists")]
    [ApiController]
    public class ListBooksByCriteriaController : Controller
    {
        private readonly IListBooksByCriteriaService _listBooksService;

        public ListBooksByCriteriaController(IListBooksByCriteriaService listBooksService)
        {
            _listBooksService = listBooksService;
        }

        //Task<HttpResponseMessage> ListBooksByYearReadAsync(DateTime yearRead);
        //Task<HttpResponseMessage> ListBooksByYearPublishedAsync(DateTime yearPublished);

        // GET: v1/booklists/by-author/{id}
        [HttpGet("by-author{id}")]
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

        // GET: v1/booklists/by-genre/{id}
        [HttpGet("by-genre{id}")]
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

        // GET: v1/booklists/by-authornationality/{id}
        [HttpGet("by-authornationality{id}")]
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

        // GET: v1/booklists/by-yearread/{id}
        [HttpGet("by-yearread{id}")]
        [ProducesResponseType(typeof(IList<Book>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ListBooksByYearRead(DateTime yearRead)
        {
            try
            {
                var books = await _listBooksService.ListBooksByYearReadAsync(yearRead);
                return Ok(books);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // GET: v1/booklists/by-yearpublished/{id}
        [HttpGet("by-yearpublished{id}")]
        [ProducesResponseType(typeof(IList<Book>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ListBooksByYearPublished(DateTime yearPublished)
        {
            try
            {
                var books = await _listBooksService.ListBooksByYearPublishedAsync(yearPublished);
                return Ok(books);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}