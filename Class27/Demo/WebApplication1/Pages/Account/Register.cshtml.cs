using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Models.Identity;

namespace WebApplication1.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public RegisterModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager
            )
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = Input.Email,
                    Email = Input.Email,
                };
                var result = await userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);

                    return LocalRedirect("~/");
                }

                foreach (var error in result.Errors)
                {
                    var errorKey =
                        error.Code.Contains("Password") ? nameof(Input.Password) :
                        error.Code.Contains("Email") ? nameof(Input.Email) :
                        error.Code.Contains("UserName") ? nameof(Input.Email) :
                        "";
                    ModelState.AddModelError(nameof(Input) + "." + errorKey, error.Description);
                }
            }

            return Page();
        }

        [BindProperty]
        public RegisterInput Input { get; set; }

        public class RegisterInput
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Required]
            [StringLength(100, MinimumLength = 6)]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare(nameof(Password))]
            public string PasswordConfirm { get; set; }
        }
    }
}