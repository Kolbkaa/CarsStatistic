using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarStatistica.Data;
using CarStatistica.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp;

namespace CarStatistica.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<User> _userManager;

        public RegisterController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (!ModelState.IsValid)
                return View("index",registerViewModel);

            var user = new User(registerViewModel.Login) { Email = registerViewModel.Email};

            var createResult = await _userManager.CreateAsync(user, registerViewModel.Password);

            if (createResult.Succeeded == false)
            {
                foreach (var error in createResult.Errors)
                {
                    ModelState.AddModelError("",error.Description);
                }

                return View("Index", registerViewModel);
            }

            return RedirectToAction("Succeed",registerViewModel);
        }

        [HttpGet]
        public IActionResult Succeed(RegisterViewModel registerViewModel)
        {
            return View(registerViewModel);
        }
    }
}