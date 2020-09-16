using System.Threading.Tasks;
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
        public Task<ApplicationUser> Register(RegisterData data)
        {
            throw new System.NotImplementedException();
        }
    }
}