using CarStatistica.Data;
using CarStatistica.Data.Repositories;
using CarStatistica.Models;
using CarStatistica.Service;
using CarStatistica.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CarStatistica.Controllers
{
    [Authorize]
    public class RefuelingController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IRefuelingRepository<Refueling> _refuelingRepository;
        public RefuelingController(UserManager<User> userManager, IRefuelingRepository<Refueling> refuelingRepository)
        {
            _userManager = userManager;
            _refuelingRepository = refuelingRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int id)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return RedirectToAction("Index", new { id = id });

            TempData["CarId"] = id;

            var listRefueling = await _refuelingRepository.GetAll(id, user);
            return View(listRefueling);
        }

        [HttpGet]
        public IActionResult Add(int id)
        {
            TempData["CarId"] = id;
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Add(RefuelingViewModel refuelingViewModel, int id)
        {
            if (!ModelState.IsValid)
                return View(refuelingViewModel);

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return RedirectToAction("Index", new { id = id });

            TempData["CarId"] = id;

            if (await _refuelingRepository.IsRefuelingGoodOrder(refuelingViewModel.GetRefueling(), id, user) == false)
            {
                ModelState.AddModelError("", "Nie prawidłowa chronologia");
                return View(refuelingViewModel);
            }

            var result = await _refuelingRepository.Add(refuelingViewModel.GetRefueling(), id, user);

            if (!result)
            {
                ModelState.AddModelError("", "Błąd dodawania kosztów");
                return View(refuelingViewModel);
            }

            return RedirectToAction("Index", new { id = id });
        }

        [HttpGet]
        public async Task<IActionResult> Average(int id)
        {
            TempData["CarId"] = id;

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return RedirectToAction("Index", new { id = id });

            var refuelingList = await _refuelingRepository.GetAll(id, user);

            return View(AverageRefuelingService.GenerateAverageRefuelingList(refuelingList));
        }

        public async Task<IActionResult> Delete(int refuelingId, int carId)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return RedirectToAction("Index", new { id = carId });

            var result = await _refuelingRepository.Delete(refuelingId, carId, user);
            //if (!result)
            return RedirectToAction("Index", new { id = carId });




        }
    }
}