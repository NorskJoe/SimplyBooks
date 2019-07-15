using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimplyBooks.Models;
using SimplyBooks.Models.Exceptions;
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

        // POST: /nationalities/add/{nationality}
        [HttpPost("add{nationality}")]
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
        [HttpPut("update{nationality}")]
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