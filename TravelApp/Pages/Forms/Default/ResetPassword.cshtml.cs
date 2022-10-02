using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using TravelApp.Pages.Account;

namespace TravelApp.Pages.Forms.Default
{
    public class ResetPasswordModel : PageModel
    {

        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<LoginModel> _logger;

        [Required]
        [BindProperty]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage ="The password and confirmation password do not match.")]
        public string ConfirmationPassword { get; set; }
        [BindProperty]
        [DataType(DataType.EmailAddress)]
        [Required]
        public string Email { get; set; }
        [BindProperty(SupportsGet =true)]
        public string code { get; set; }


        public ResetPasswordModel(UserManager<IdentityUser> userManager, ILogger<LoginModel> logger)
        {
            _userManager = userManager;
            _logger = logger;
        }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.FindByEmailAsync(Email);
            var result = await _userManager.ResetPasswordAsync(user, code, Password);
            if(result.Succeeded)
            {
                return RedirectToPage("/Account/Login");
            }
            else
            {
                return Page();
            }
        }

    }
}