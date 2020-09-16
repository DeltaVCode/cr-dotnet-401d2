using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Web.Models;
using Web.Models.Api;

namespace Web.Services
{
    public interface IUserService
    {
        Task<ApplicationUser> Register(RegisterData data);
    }

    public class IdentityUserService : IUserService
    {
        private readonly UserManager<ApplicationUser> userManager;

        public IdentityUserService(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<ApplicationUser> Register(RegisterData data)
        {
            var user = new ApplicationUser
            {
                UserName = data.Username,
                Email = data.Email,
                PhoneNumber = data.PhoneNumber,
            };

            var result = await userManager.CreateAsync(user, data.Password);
            if (result.Succeeded)
            {
                return user;
            }

            return null;
        }
    }
}