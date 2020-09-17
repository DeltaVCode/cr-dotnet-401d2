using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Models.Api;
using Web.Services;

namespace Web.Controllers
{
    // [Authorize] // Replace this with a controller filter
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("Register")]
        public async Task<ActionResult<UserDto>> Register(RegisterData data)
        {
            UserDto user = await userService.Register(data, this.ModelState);
            if (!ModelState.IsValid)
            {
                return BadRequest(new ValidationProblemDetails(ModelState));
            }

            return user;
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<ActionResult<UserDto>> Login(LoginData data)
        {
            var user = await userService.Authenticate(data.Username, data.Password);

            if (user == null)
            {
                return Unauthorized();
            }

            return user;
        }

        [HttpGet("Self")]
        public async Task<ActionResult<UserDto>> Self()
        {
            return await userService.GetUser(this.User);
        }
    }
}