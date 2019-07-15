using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimplyBooks.Models;
using SimplyBooks.Services.Genres;

namespace SimplyBooks.Web.Controllers.Genres
{
    [Route("genres")]
    [ApiController]
    public class GenresController : Controller
    {
        private readonly IGenresService _genresService;

        public GenresController(IGenresService genresService)
        {
            _genresService = genresService;
        }

        // GET: /genres/list
        [HttpGet("list")]
        [ProducesResponseType(typeof(IList<Genre>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ListAllGenres()
        {
            var result = await _genresService.ListAllGenresAsync();
            return Ok(result);
        }

        // POST: /genres/add/{genre}
        [HttpPost("add{genre}")]
        [ProducesResponseType(typeof(Genre), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddGenre([FromBody]Genre genre)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _genresService.AddGenreAsync(genre);
            return Ok(result);
        }

        // PUT: /genres/update/{genre}
        [HttpPut("update{genre}")]
        [ProducesResponseType(typeof(Genre), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateGenre(Genre genre)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _genresService.UpdateGenreAsync(genre);
            return Ok(result);
        }

    }
}