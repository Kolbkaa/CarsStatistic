using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarStatistica.Data;
using CarStatistica.Data.Repositories;
using CarStatistica.Models;
using CarStatistica.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CarStatistica.Controllers
{
    [Authorize]
    public class CarController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly ICarRepository<Car> _carRepository;
        public CarController(UserManager<User> userManager, ICarRepository<Car> carRepository)
        {
            _userManager = userManager;
            _carRepository = carRepository;

        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(CarViewModel carViewModel)
        {
            if (!ModelState.IsValid)
                return View(carViewModel);

            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                ModelState.AddModelError("","Błąd użytkownika");
                return View(carViewModel);
            }

            var car = carViewModel.GetCar();
            car.User = user;
            car.ActualMileage = car.StartMileage;

            var result = await _carRepository.Add(car);

            if(!result)
            {
                ModelState.AddModelError("", "Błąd dodawania pojazdu");
                return View(carViewModel);
            }

            return RedirectToAction("index");
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return View();

            var carList = await _carRepository.GetAll(user);
            return View(carList);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return RedirectToAction("Index");

            var carToDelete = await _carRepository.Get(id, user);

            return View(carToDelete);
        }

        [HttpGet]
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return RedirectToAction("Index");

            var result = await _carRepository.Delete(id, user);

            if (!result)
            {
                return RedirectToAction("Index");
            }
            
            return RedirectToAction("Index");

        }

       
    }
}