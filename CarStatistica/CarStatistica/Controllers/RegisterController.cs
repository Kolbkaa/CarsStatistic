using CarStatistica.Data;
using CarStatistica.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CarStatistica.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<User> _userManager;

        public RegisterController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (!ModelState.IsValid)
                return View(registerViewModel);

            var user = new User(registerViewModel.Login) { Email = registerViewModel.Email };

            var createResult = await _userManager.CreateAsync(user, registerViewModel.Password);

            TempData["UserName"] = registerViewModel.Login;

            if (createResult.Succeeded == false)
            {
                foreach (var error in createResult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View(registerViewModel);
            }

            return RedirectToAction("Succeed");
        }

        [HttpGet]
        public IActionResult Succeed(RegisterViewModel registerViewModel)
        {
            return View(registerViewModel);
        }
    }
}