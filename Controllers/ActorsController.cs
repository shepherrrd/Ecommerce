using Ecommerce.Data;
using Ecommerce.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Ecommerce.Controllers
{
    public class ActorsController : Controller
    {
        private readonly IActorsService _actorsService;
        public ActorsController(IActorsService actorsService)
        {
           _actorsService= actorsService;

        }
        public async Task<IActionResult> Index()
        {
            var actors = await _actorsService.GetAll();
            

            
            return View(actors);
        }

        public async Task<IActionResult> Create()
        {
            
            return View();
        }
    }
}
