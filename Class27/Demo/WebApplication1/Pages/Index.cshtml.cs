using System.Security.Claims;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace WebApplication1.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            Username = User.FindFirst(ClaimTypes.Name)?.Value;
            MethodAndPath = $"{Request.Method} {Request.Path}";
        }

        public string Username { get; private set; }

        public string MethodAndPath { get; set; }
    }
}