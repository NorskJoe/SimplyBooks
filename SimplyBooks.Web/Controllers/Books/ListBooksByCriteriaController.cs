using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimplyBooks.Models;
using SimplyBooks.Services.Books.Interfaces;

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
        public async Task<ActionResult<IList<Book>>> ListBooksByAuthor(int authorId)
        {
            try
            {
                var books = await _listBooksService.ListBooksByAuthorAsync(authorId);
                return Ok(books);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        // GET: v1/booklists/by-genre/{id}
        [HttpGet("by-genre{id}")]
        [ProducesResponseType(typeof(IList<Book>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IList<Book>>> ListBooksByGenre(int genreId)
        {
            try
            {
                var books = await _listBooksService.ListBooksByGenreAsync(genreId);
                return Ok(books);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        // GET: v1/booklists/by-authornationality/{id}
        [HttpGet("by-authornationality{id}")]
        [ProducesResponseType(typeof(IList<Book>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IList<Book>>> ListBooksByAuthorNationality(int nationalityId)
        {
            try
            {
                var books = await _listBooksService.ListBooksByAuthorNationalityAsync(nationalityId);
                return Ok(books);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        // GET: v1/booklists/by-yearread/{id}
        [HttpGet("by-yearread{id}")]
        [ProducesResponseType(typeof(IList<Book>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IList<Book>>> ListBooksByYearRead(DateTime yearRead)
        {
            try
            {
                var books = await _listBooksService.ListBooksByYearReadAsync(yearRead);
                return Ok(books);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        // GET: v1/booklists/by-yearpublished/{id}
        [HttpGet("by-yearpublished{id}")]
        [ProducesResponseType(typeof(IList<Book>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IList<Book>>> ListBooksByYearPublished(DateTime yearPublished)
        {
            try
            {
                var books = await _listBooksService.ListBooksByYearPublishedAsync(yearPublished);
                return Ok(books);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}