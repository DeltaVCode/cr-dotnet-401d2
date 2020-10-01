using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Demo.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Demo.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IUploadService upload;

        public IndexModel(ILogger<IndexModel> logger, IUploadService upload)
        {
            _logger = logger;
            this.upload = upload;
        }

        [TempData]
        public string UploadedFileName { get; set; }

        [TempData]
        public string UploadedFileLink { get; set; }

        [BindProperty]
        [Required]
        public string Name { get; set; }

        [BindProperty]
        public IFormFile Image { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (Image == null)
            {
                ModelState.AddModelError(nameof(Image), "Image is required!");
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            // We can assume we got an Image
            UploadedFileName = Image.FileName;

            using var stream = Image.OpenReadStream();
            UploadedFileLink = await upload.UploadFile(Image.FileName, stream);

            return LocalRedirect("/");
        }
    }
}