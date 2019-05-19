using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimplyBooks.Models;
using SimplyBooks.Models.Exceptions;
using SimplyBooks.Services.Nationalities;

namespace SimplyBooks.Web.Controllers.Nationalities
{
    [Route("v1/nationalities")]
    [ApiController]
    public class NationalitiesController : Controller
    {
        private readonly INationalityService _nationalityService;

        public NationalitiesController(INationalityService nationalityService)
        {
            _nationalityService = nationalityService;
        }

        // POST: v1/nationalities/add/{nationality}
        [HttpPost("add{nationality}")]
        [ProducesResponseType(typeof(Nationality), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<ActionResult> AddNationality([FromBody]Nationality nationality)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _nationalityService.AddNationalityAsync(nationality);
            }
            catch (EntityAlreadyExistsException ex)
            {
                return Conflict(ex.Message);
            }

            return Ok(nationality);
        }

        // PUT: v1/nationalities/update/{nationality}
        [HttpPut("update{nationality}")]
        [ProducesResponseType(typeof(Nationality), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> UpdateNationality(Nationality nationality)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _nationalityService.UpdateNationalityAsync(nationality);
                return Ok(nationality);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}