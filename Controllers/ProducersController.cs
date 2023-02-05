using Ecommerce.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Controllers
{
    public class ProducersController : Controller
    {
        private readonly dbContext _context;
        public ProducersController(dbContext context)
        {
            _context = context;

        }
        public async  Task<IActionResult> Index()
        {
            var producers = await _context.Producer.ToListAsync();
            return View(producers);
        }
    }
}
