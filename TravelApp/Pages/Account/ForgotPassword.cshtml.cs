using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using TravelApp.Pages.Account;
using TravelApp.Services;
using TravelApp.Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity.UI.Services;
using System.Text.Encodings.Web;

namespace TravelApp.Pages.Forms
{
    public class ForgotPassworldModel : PageModel
    {

        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ILogger<LoginModel> _logger;
        private readonly IEmailSender _emailSender;

        public ForgotPassworldModel(SignInManager<IdentityUser> signInManager,
            ILogger<LoginModel> logger,
            UserManager<IdentityUser> userManager, IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
        }

        [BindProperty]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var appUser = await _userManager.FindByEmailAsync(Email);
               
                    var code = await _userManager.GeneratePasswordResetTokenAsync(appUser).ConfigureAwait(false);
                    var callbackUrl = Url.Page(
                        "/Forms/Default/ResetPassword",
                        pageHandler: null,
                        values: new { code },
                        protocol: Request.Scheme
                        );
                    var subject = "Reset Password";
                    var htmlMessage = $"Please reset your password by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.";

                    await _emailSender.SendEmailAsync(Email, subject, htmlMessage);

                    return RedirectToPage("/Index");
       
            }
            return RedirectToPage("/Index");
        }
    }
}