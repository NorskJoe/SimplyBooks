using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimplyBooks.Domain;
using SimplyBooks.Domain.QueryModels;
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

        // GET
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Result<GenreSelectList>>> SelectList()
        {
            return Ok(await _genresService.SelectList());
        }

        // POST
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Result>> AddGenre([FromBody]Genre genre)
        {
            if (!ModelState.IsValid || genre == null)
            {
                return BadRequest(ModelState);
            }

            var result = await _genresService.AddGenreAsync(genre);
            return Ok(result);
        }

        // PUT
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Result>> UpdateGenre(Genre genre)
        {
            if (!ModelState.IsValid || genre == null)
            {
                return BadRequest(ModelState);
            }

            var result = await _genresService.UpdateGenreAsync(genre);
            return Ok(result);
        }

    }
}