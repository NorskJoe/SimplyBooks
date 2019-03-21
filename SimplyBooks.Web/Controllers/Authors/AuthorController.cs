using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimplyBooks.Models;
using SimplyBooks.Services.Authors.Interfaces;

namespace SimplyBooks.Web.Controllers.Authors
{
    [Route("v1/authors")]
    [ApiController]
    public class AuthorsController : Controller
    {
        private readonly IAuthorsService _authorsService;

        public AuthorsController(IAuthorsService authorsService)
        {
            _authorsService = authorsService;
        }

        // PUT: v1/authors/update/{author}
        [HttpPut("update{author}")]
        [ProducesResponseType(typeof(Author), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> UpdateAuthor(Author author)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                var updatedAuthor = await _authorsService.UpdateAuthorAsync(author);
                return Ok(updatedAuthor);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        // POST: v1/authors/add/{author}
        [HttpPost("add{author}")]
        [ProducesResponseType(typeof(Author), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> AddAuthor([FromBody]Author author)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var newAuthor = await _authorsService.AddAuthorAsync(author);
            return Ok(newAuthor);
        }
    }
}