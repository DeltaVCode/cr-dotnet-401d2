using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Web.Models;
using Web.Models.Api;
using Web.Services;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost("Register")]
        public async Task<ActionResult<ApplicationUser>> Register(RegisterData data)
        {
            ApplicationUser user = await userService.Register(data);
            return user;
        }
    }
}