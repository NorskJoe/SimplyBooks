using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace SimplyBooks.Services.Authentication
{
    public interface IApplicationUserProvider
    {
        public Task<ApplicationUser> GetUser();
    }

    public class ApplicationUserProvider : IApplicationUserProvider
    {
        private readonly IHttpContextAccessor _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public ApplicationUserProvider(IHttpContextAccessor context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<ApplicationUser> GetUser()
        {
            return await _userManager.FindByEmailAsync(_context.HttpContext.User?.Identity?.Name);
        }
    }
}
