using Ecommerce.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Controllers
{
    public class MoviesController : Controller
    {
        private readonly dbContext _context;
        public MoviesController(dbContext context)
        {
            _context = context;

        }
        public async Task<IActionResult> Index()
        {
            var movies = await _context.Movie.Include(n => n.Cinema).OrderBy(n => n.Name).ToListAsync();
            return View(movies);
        }
    }
}
