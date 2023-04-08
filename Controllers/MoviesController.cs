using Ecommerce.Data;
using Ecommerce.Data.RequestHandlers.CinemaRequestHandler;
using Ecommerce.Data.RequestHandlers.MoviesRequestHandlers;
using Ecommerce.Data.ViewModel;
using Ecommerce.Models;
using Ecommerce.Models.Validators.ModelViewValidators;
using Ecommerce.Models.Validators.ProducerValidator;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Ecommerce.Controllers
{
    public class MoviesController : Controller
    {
        private readonly ISender _movieServcie;
        public MoviesController(ISender movieServcie)
        {
            _movieServcie = movieServcie;
        }

        //private readonly dbContext _context;
        //public MoviesController(dbContext context)
        //{
        //    _context = context;

        //}
        public async Task<IActionResult> Index()
        {
            //var movies = await _context.Movie.Include(n => n.Cinema).OrderBy(n => n.Name).ToListAsync();
            //return View(movies);
            var movie= await _movieServcie.Send(new GetMovies());
            return View(movie);

        }
         public async Task<IActionResult> Filter(string searchString)
        {
            //var movies = await _context.Movie.Include(n => n.Cinema).OrderBy(n => n.Name).ToListAsync();
            //return View(movies);
            var movie= await _movieServcie.Send(new GetMovies());

            if (!string.IsNullOrEmpty(searchString))
            {

                var filteredResults = movie.Where(n => n.Name.Contains(searchString) || n.Description.Contains(searchString)).ToList();
                if (filteredResults.IsNullOrEmpty())
                {
                    return View("NotFound");
                }
                else
                {
                    return View("Index", filteredResults);
                }

            }
            return View("Index", movie);
        }

        public async Task<IActionResult> Details(int id)
        {
            var getMovie = new GetMovieById { Id = id };
            var movieDetails = await _movieServcie.Send(getMovie);

            if (movieDetails == null)
            {
                return RedirectToAction(nameof(Index));

            }
            return View(movieDetails);

        }
        public async Task<IActionResult> Create()
        {
            var movieDropDownData = await _movieServcie.Send(new MovieDropDown());

            ViewBag.Cinemas = new SelectList(movieDropDownData.Cinemas, "Id", "Name");
            ViewBag.Producers = new SelectList(movieDropDownData.Producers, "Id", "FullName");
            ViewBag.Actors = new SelectList(movieDropDownData.Actors, "Id", "FullName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(MovieVM movie)
        {
            movieVmValidators movieVMValidator = new movieVmValidators();
            ValidationResult result = await movieVMValidator.ValidateAsync(movie);

            if (!result.IsValid) {
                foreach (var failure in result.Errors)
                {
                    var movieDropDownData = await _movieServcie.Send(new MovieDropDown());

                    ViewBag.Cinemas = new SelectList(movieDropDownData.Cinemas, "Id", "Name");
                    ViewBag.Producers = new SelectList(movieDropDownData.Producers, "Id", "FullName");
                    ViewBag.Actors = new SelectList(movieDropDownData.Actors, "Id", "FullName");
                    //ModelState.AddModelError(failure.ErrorCode, failure.ErrorMessage);
                    ModelState.AddModelError(failure.PropertyName, failure.ErrorMessage);
                }
                return View(movie);

            }

            await _movieServcie.Send(new AddMovie { data = movie });
            return RedirectToAction("Index");
        }
         public async Task<IActionResult> Edit(int id)
        {
            var getMovie = new GetMovieById { Id = id };
            var movieDetails = await _movieServcie.Send(getMovie);

            if (movieDetails == null)
            {
                return RedirectToAction(nameof(Index));

            }

            var response = new MovieVM()
            {
                Id = movieDetails.Id,
                Name = movieDetails.Name,
                Description = movieDetails.Description,
                Price = movieDetails.Price,
                StartDate = movieDetails.StartDate,
                EndDate = movieDetails.EndDate,
                ImageURL = movieDetails.ImageURL,
                MovieCategory = movieDetails.MovieCategory,
                CinemaId = movieDetails.CinemaId,
                ProducerId = movieDetails.ProducerId,
                ActorIds = movieDetails.Actor_Movies.Select(n => n.ActorId).ToList(),
            };

            var movieDropDownData = await _movieServcie.Send(new MovieDropDown());

            ViewBag.Cinemas = new SelectList(movieDropDownData.Cinemas, "Id", "Name");
            ViewBag.Producers = new SelectList(movieDropDownData.Producers, "Id", "FullName");
            ViewBag.Actors = new SelectList(movieDropDownData.Actors, "Id", "FullName");
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int Id,MovieVM movie)
        {
            if (Id != movie.Id) return View("NotFound");

            movieVmValidators movieVMValidator = new movieVmValidators();
            ValidationResult result = await movieVMValidator.ValidateAsync(movie);

            if (!result.IsValid) {
                foreach (var failure in result.Errors)
                {
                    var movieDropDownData = await _movieServcie.Send(new MovieDropDown());

                    ViewBag.Cinemas = new SelectList(movieDropDownData.Cinemas, "Id", "Name");
                    ViewBag.Producers = new SelectList(movieDropDownData.Producers, "Id", "FullName");
                    ViewBag.Actors = new SelectList(movieDropDownData.Actors, "Id", "FullName");
                    //ModelState.AddModelError(failure.ErrorCode, failure.ErrorMessage);
                    ModelState.AddModelError(failure.PropertyName, failure.ErrorMessage);
                }
                return View(movie);

            }

            await _movieServcie.Send(new UpdateMovie { data = movie });
            return RedirectToAction("Index");
        }

    }
}
