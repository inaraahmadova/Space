using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SpaceWeb.Models;
using SpaceWeb.ViewModels.Account;

namespace SpaceWeb.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public AccountController(UserManager<User> userManager,SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            User newuser = new User()
            {
                Name = registerVM.Name,
                Email = registerVM.Email,
                Surname = registerVM.Surname,
                UserName = registerVM.Username
            };
            var result = await userManager.CreateAsync(newuser, registerVM.Password);
            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
                return View();
            }
            return RedirectToAction("Login");
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var user =await userManager.FindByNameAsync(loginVM.Username);
            if (user == null)
            {
                ModelState.AddModelError("", "us,ps Yalnishdir");
            }
            var result = await signInManager.CheckPasswordSignInAsync(user, loginVM.Password, true);
            if(result.IsLockedOut)
            {
                ModelState.AddModelError("", "birazdan gelersiz");
                return View();
            }
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "us,ps Yalnishdir");
                return View();
            }
            await signInManager.SignInAsync(user, loginVM.RememberMe);
            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
