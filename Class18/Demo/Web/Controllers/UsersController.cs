using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<ActionResult<UserDto>> Register(RegisterData data)
        {
            UserDto user = await userService.Register(data, this.ModelState);
            if (!ModelState.IsValid)
            {
                return BadRequest(new ValidationProblemDetails(ModelState));
            }

            return user;
        }
    }
}