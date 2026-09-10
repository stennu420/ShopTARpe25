using Microsoft.AspNetCore.Mvc;
using ShopTARpe25.Core.Dto;
using ShopTARpe25.Core.ServiceInterface;
using ShopTARpe25.Models.Spaceship;

namespace ShopTARpe25.Controllers
{
    public class SpaceshipController : Controller
    {
      private readonly ISpaceshipServices _spaceshipServices;
     

        public SpaceshipController(ISpaceshipServices SpaceshipService)
        {
            _spaceshipServices = SpaceshipService;
        }
     
        
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
            //luua vaheinstants,mis sisaldab andmeid,mis on saadud vorimst
            //need andmed edasi saata dto-sse,mis on mõeldud andmebaasi salvestmiseks

            var dto = new SpaceshipDto
            {
                Name = vm.Name,
                Classification = vm.Classification,
                BuildDate = vm.BuildDate,
                CreatedAt = vm.CreatedAt,
                Crew = vm.Crew,
                EnginePower = vm.EnginePower
            };
            // kutsuda teenuse meetodit,mis salvestab andemd adnemebaasi
            var result = await _spaceshipServices.Create(dto);

            return RedirectToAction(nameof(Index));
        }

       
    }
}
