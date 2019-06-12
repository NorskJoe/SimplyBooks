using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimplyBooks.Models;
using SimplyBooks.Models.Exceptions;
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

        // POST: v1/genres/add/{genre}
        [HttpPost("add{genre}")]
        [ProducesResponseType(typeof(Genre), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<ActionResult> AddGenre([FromBody]Genre genre)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _genresService.AddGenreAsync(genre);
            }
            catch (EntityAlreadyExistsException ex)
            {
                return Conflict(ex.Message);
            }

            return Ok(genre);
        }

        // PUT: v1/genres/update/{genre}
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
                await _genresService.UpdateGenreAsync(genre);
                return Ok(genre);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

    }
}