using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using DAL.App.EF;
using Domain;
using Domain.App;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Domain.App.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace WebApp.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<AppRole> _roleManager;
        
        private readonly ApplicationDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly IWebHostEnvironment _env;

        public RegisterModel(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            ApplicationDbContext context,
            IWebHostEnvironment env, 
            RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _context = context;
            _env = env;
            _roleManager = roleManager;
        }

        [BindProperty] public InputModel Input { get; set; } = default!;

        public string? ReturnUrl { get; set; }

        public IList<AuthenticationScheme>? ExternalLogins { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; } = default!;

            [MaxLength(128)]
            [MinLength(1)]
            [Display(Name = "FirstName")]
            public string FirstName { get; set; } = default!;

            [MaxLength(128)]
            [MinLength(1)]
            [Display(Name = "LastName")]
            public string LastName { get; set; } = default!;

            public PersonType PersonType { get; set; } = default!;

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.",
                MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; } = default!;

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; } = default!;
        }

        public async Task OnGetAsync(string? returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string? returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var user = new AppUser
                {
                    UserName = Input.Email,
                    FirstName = Input.FirstName,
                    LastName = Input.LastName,
                    //PersonType = Input.PersonType,
                    Email = Input.Email
                };
                var result = await _userManager.CreateAsync(user, Input.Password);
                var role = new AppRole();
                role.Name = "User";
                role.DisplayName = "User";
                await _roleManager.CreateAsync(role);

                result = _userManager.AddToRoleAsync(user, "User").Result;
                Family f = new Family();
                _context.Add(f);
                _context.SaveChanges();
                List<string> logos = _env.WebRootFileProvider.GetDirectoryContents("Icons")
                    .Select(item=>item.Name).ToList();
                Random rnd = new Random();
                string logo = logos[rnd.Next(logos.Count)];
                Person p = new Person();
                p.AppUser = user;
                p.AppUserId = user.Id;
                p.PersonType = Input.PersonType;
                p.FirstName = Input.FirstName;
                p.LastName = Input.LastName;
                p.Family = f;
                p.FamilyId = f.Id;
                p.Logo = "/Icons/" + logo;
                _context.Add(p);
                _context.SaveChanges();
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = user.Id, code = code },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email });
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
