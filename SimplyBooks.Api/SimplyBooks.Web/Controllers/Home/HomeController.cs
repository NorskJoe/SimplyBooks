using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimplyBooks.Services.Home;

namespace SimplyBooks.Web.Controllers.Home
{
    [Route("home")]
    [ApiController]
    public class HomeController : Controller
    {
        private readonly IHomeService _homeService;

        public HomeController(IHomeService homeService)
        {
            _homeService = homeService;
        }

        // GET: /home/list-recent
        [HttpGet("list-recent")]
        [ProducesResponseType(typeof(RecentBooksList), StatusCodes.Status200OK)]
        public async Task<IActionResult> ListRecentBooks()
        {
            return Ok(await _homeService.GetRecentBooks());
        }
    }
}
