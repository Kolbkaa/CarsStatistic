using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarStatistica.Data;
using CarStatistica.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CarStatistica.Controllers
{
    
    public class LoginController : Controller
    {
        private readonly SignInManager<User> _signInManager;

        public LoginController(SignInManager<User> signInManager)
        {
            _signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
                return View("index", loginViewModel);

            var loginResult = await _signInManager.PasswordSignInAsync(loginViewModel.Password, loginViewModel.Password,
                loginViewModel.RememberMe, false);

            if (loginResult.Succeeded == false)
            {
                ModelState.AddModelError("","Nie można się zalogować");
                return View("index", loginViewModel);
            }

            return RedirectToAction("Index", "Home");
        }
    }
}