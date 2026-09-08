using Microsoft.AspNetCore.Mvc;
using ShopTARpe25.Models.Spaceship;

namespace ShopTARpe25.Controllers
{
    public class SpaceshipController : Controller
    {
      

       
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult Create() 
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(SpaceshipCreateViewModel vm) 
        {
            return RedirectToAction(nameof(Index));
        }
    }
}
