using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimplyBooks.Domain;
using SimplyBooks.Domain.QueryModels;
using SimplyBooks.Repository.Queries.Authors;
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Result<PagedResult<AuthorListItem>>>> ListAuthors([FromQuery]AuthorListCriteria criteria)
        {
            if (!ModelState.IsValid || criteria == null)
            {
                return BadRequest(ModelState);
            }

            var result = await _authorsService.ListAuthorsAsync(criteria);
            return Ok(result);
        }

        // GET: /authors/select-list
        [HttpGet("select-list")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Result<AuthorSelectList>>> SelectList()
        {
            return Ok(await _authorsService.SelectList());
        }

        // POST
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Result>> AddAuthor([FromBody]Author author)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _authorsService.AddAuthorAsync(author);
            return Ok(result);
        }

        // PUT
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Result>> UpdateAuthor(Author author)
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