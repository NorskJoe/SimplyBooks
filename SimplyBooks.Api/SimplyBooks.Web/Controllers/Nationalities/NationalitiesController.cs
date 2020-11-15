using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimplyBooks.Domain;
using SimplyBooks.Domain.QueryModels;
using SimplyBooks.Services.Nationalities;

namespace SimplyBooks.Web.Controllers.Nationalities
{
    [Route("nationalities")]
    [ApiController]
    public class NationalitiesController : Controller
    {
        private readonly INationalityService _nationalityService;

        public NationalitiesController(INationalityService nationalityService)
        {
            _nationalityService = nationalityService;
        }

        // GET
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Result<NationalitySelectList>>> SelectList()
        {
            return Ok(await _nationalityService.SelectList());
        }

        // POST
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Result>> AddNationality([FromBody]Nationality nationality)
        {
            if (!ModelState.IsValid || nationality == null)
            {
                return BadRequest(ModelState);
            }

            var result = await _nationalityService.AddNationalityAsync(nationality);
            return Ok(result);
        }

        // PUT
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Result>> UpdateNationality(Nationality nationality)
        {
            if (!ModelState.IsValid || nationality == null)
            {
                return BadRequest(ModelState);
            }

            var result = await _nationalityService.UpdateNationalityAsync(nationality);
            return Ok(result);
        }
    }
}