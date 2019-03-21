using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimplyBooks.Models;
using SimplyBooks.Services.Genres.Interfaces;

namespace SimplyBooks.Web.Controllers.Genres
{
    [Route("v1/[controler")]
    [ApiController]
    public class GenresController : Controller
    {
        private readonly IGenresService _genresService;

        public GenresController(IGenresService genresService)
        {
            _genresService = genresService;
        }

        // PUT: v1/{controller}/update/{genre}
        [HttpPut("update{genre}")]
        [ProducesResponseType(typeof(Genre), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> UpdateGenre(Genre genre)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var updatedGenre = await _genresService.UpdateGenreAsync(genre);
                return Ok(updatedGenre);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        // POST: v1/{controller}/add/{genre}
        [HttpPost("add{genre}")]
        [ProducesResponseType(typeof(Genre), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> AddGenre([FromBody]Genre genre)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var newGenre = await _genresService.AddGenreAsync(genre);
            return Ok(newGenre);
        }
    }
}