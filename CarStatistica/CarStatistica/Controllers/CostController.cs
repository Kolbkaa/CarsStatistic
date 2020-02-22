using Microsoft.AspNetCore.Mvc;

namespace CarStatistica.Controllers
{
    public class CostController : Controller
    {
        public IActionResult Index(int id)
        {
            return View(id);
        }
    }
}