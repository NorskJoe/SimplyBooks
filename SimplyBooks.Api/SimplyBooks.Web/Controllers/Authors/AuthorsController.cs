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
        [ProducesResponseType(typeof(Result<PagedResult<AuthorListItem>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ListAuthors([FromQuery]AuthorListCriteria criteria)
        {
            return Ok(await _authorsService.ListAuthorsAsync(criteria));
        }

        // GET: /authors/select-list
        [HttpGet("select-list")]
        [ProducesResponseType(typeof(AuthorSelectList), StatusCodes.Status200OK)]
        public async Task<IActionResult> SelectList()
        {
            return Ok(await _authorsService.SelectList());
        }

        // POST
        [HttpPost]
        [ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
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

        // PUT
        [HttpPut]
        [ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
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