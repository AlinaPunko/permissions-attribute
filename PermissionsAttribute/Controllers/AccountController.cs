using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PermissionsAttribute.Constants;
using PermissionsAttribute.ViewModels;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace PermissionsAttribute.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            IdentityUser user = new IdentityUser { Email = model.Email, UserName = model.Email};
            IdentityResult result = await userManager.CreateAsync(user, model.Password);
            Random rnd = new Random();
            int permissionNumber = rnd.Next(1, 6);
            Enum.TryParse(permissionNumber.ToString(), out Permissions permission);
            Claim claim = new Claim("permission", permission.ToString());
            if (result.Succeeded)
            {
                await signInManager.SignInAsync(user, false);
                await userManager.AddClaimAsync(user, claim);
                return RedirectToAction("Index", "Home");
            }

            foreach (IdentityError error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            return View(new LoginViewModel { ReturnUrl = returnUrl });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            SignInResult result = await signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
            if (result.Succeeded)
            {
                if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                {
                    return Redirect(model.ReturnUrl);
                }

                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Неправильный логин и (или) пароль");
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}