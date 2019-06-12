﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimplyBooks.Models;
using SimplyBooks.Models.Exceptions;
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

        // POST: v1/authors/add/{author}
        [HttpPost("add{author}")]
        [ProducesResponseType(typeof(Author), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> AddAuthor([FromBody]Author author)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _authorsService.AddAuthorAsync(author);
            }
            catch (EntityAlreadyExistsException ex)
            {
                return Conflict(ex.Message);
            }
            return Ok(author);
        }

        // PUT: v1/authors/update/{author}
        [HttpPut("update{author}")]
        [ProducesResponseType(typeof(Author), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateAuthor(Author author)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _authorsService.UpdateAuthorAsync(author);
                return Ok(author);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}