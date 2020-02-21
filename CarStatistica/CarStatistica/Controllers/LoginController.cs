using CarStatistica.Data;
using CarStatistica.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CarStatistica.Controllers
{
    [Authorize]
    public class LoginController : Controller
    {
        private readonly SignInManager<User> _signInManager;

        public LoginController(SignInManager<User> signInManager)
        {
            _signInManager = signInManager;
        }
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
                return View(loginViewModel);

            var loginResult = await _signInManager.PasswordSignInAsync(loginViewModel.Login, loginViewModel.Password,
                loginViewModel.RememberMe, false);

            if (loginResult.Succeeded == false)
            {
                
                ModelState.AddModelError("","Nie można się zalogować");
                return View(loginViewModel);
            }

            return RedirectToAction("Succeed");
        }

        [HttpGet]
        public IActionResult Succeed()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}