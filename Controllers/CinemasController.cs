using Ecommerce.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Controllers
{
    public class CinemasController : Controller
    {
        private readonly dbContext _context;
        public CinemasController(dbContext context)
        {
            _context = context; 

        }
        public async Task<IActionResult> Index()
        {
            var cinemas = await  _context.Cinema.ToListAsync();
            return View(cinemas);
        }
    }
}
