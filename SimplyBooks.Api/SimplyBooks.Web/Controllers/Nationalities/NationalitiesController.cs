using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimplyBooks.Models;
using SimplyBooks.Repository.Queries.Authors;
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

        // GET: /nationalities/list
        [HttpGet("list")]
        [ProducesResponseType(typeof(IList<Nationality>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ListAllNationalities()
        {
            var result = await _nationalityService.ListAllNationalitiesAsync();
            return Ok(result);
        }

        // GET: /nationalities/select-list
        [HttpGet("select-list")]
        [ProducesResponseType(typeof(NationalitySelectList), StatusCodes.Status200OK)]
        public async Task<IActionResult> SelectList()
        {
            return Ok(await _nationalityService.SelectList());
        }

        // POST: /nationalities/add/{nationality}
        [HttpPost("add")]
        [ProducesResponseType(typeof(Nationality), StatusCodes.Status200OK)]
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

        // PUT: /nationalities/update/{nationality}
        [HttpPut("update")]
        [ProducesResponseType(typeof(Nationality), StatusCodes.Status200OK)]
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