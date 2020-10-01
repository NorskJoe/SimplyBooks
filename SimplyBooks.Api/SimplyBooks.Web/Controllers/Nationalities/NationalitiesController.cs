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
        [ProducesResponseType(typeof(NationalitySelectList), StatusCodes.Status200OK)]
        public async Task<IActionResult> SelectList()
        {
            return Ok(await _nationalityService.SelectList());
        }

        // POST
        [HttpPost]
        [ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddNationality([FromBody]Nationality nationality)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _nationalityService.AddNationalityAsync(nationality);
            return Ok(result);
        }

        // PUT
        [HttpPut]
        [ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> UpdateNationality(Nationality nationality)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _nationalityService.UpdateNationalityAsync(nationality);
            return Ok(result);
        }
    }
}