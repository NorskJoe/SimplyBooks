﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimplyBooks.Models;
using SimplyBooks.Services.Authors;

namespace SimplyBooks.Web.Controllers.Authors
{
    [Route("authors")]
    [ApiController]
    public class AuthorsController : Controller
    {
        private readonly IAuthorsService _authorsService;

        public AuthorsController(IAuthorsService authorsService)
        {
            _authorsService = authorsService;
        }

        // GET: /authors/list
        [HttpGet("list")]
        [ProducesResponseType(typeof(AuthorList), StatusCodes.Status200OK)]
        public async Task<IActionResult> ListAllAuthors()
        {
            return Ok(await _authorsService.ListAllAuthorsAsync());
        }

        // GET: /authors/select-list
        [HttpGet("select-list")]
        [ProducesResponseType(typeof(AuthorSelectList), StatusCodes.Status200OK)]
        public async Task<IActionResult> SelectList()
        {
            return Ok(await _authorsService.SelectList());
        }

        // POST: /authors/add/{author}
        [HttpPost("add")]
        [ProducesResponseType(typeof(Author), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddAuthor([FromBody]Author author)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _authorsService.AddAuthorAsync(author);
            return Ok(result);
        }

        // PUT: /authors/update/{author}
        [HttpPut("update")]
        [ProducesResponseType(typeof(Author), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateAuthor(Author author)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _authorsService.UpdateAuthorAsync(author);
            return Ok(result);
        }
    }
}