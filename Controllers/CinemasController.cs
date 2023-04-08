using Ecommerce.Data;
using Ecommerce.Data.RequestHandlers.CinemaRequestHandler;
using Ecommerce.Models;
using Ecommerce.Models.Validators.CinemaValidator;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Controllers
{
    public class CinemasController : Controller
    {
        private readonly ISender _cinemaService;
        public CinemasController(ISender cinemaService)
        {
            _cinemaService = cinemaService;

        }
        
        public async Task<IActionResult> Index()
        {
           var cinemas = await _cinemaService.Send(new GetCinema());
           return View(cinemas);
        }

        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Cinema cinema)

        {
            CinemaValidator producerValidator = new CinemaValidator();
            ValidationResult result = await producerValidator.ValidateAsync(cinema);
            if (!result.IsValid)
            {
                foreach (var failure in result.Errors)
                {
                    //ModelState.AddModelError(failure.ErrorCode, failure.ErrorMessage);
                    ModelState.AddModelError(failure.PropertyName, failure.ErrorMessage);
                }
                return View(cinema);
            }

            await _cinemaService.Send(new AddCinema { cinema = cinema});

            return RedirectToAction(nameof(Index));

        }


        public async Task<IActionResult> Details(int id)
        {
            var getCinema = new GetCinemaById { Id = id };
            
            

            
            var cinemaDetails = await _cinemaService.Send(getCinema);

            if (cinemaDetails == null)
            {
                return RedirectToAction(nameof(Index));

            }
            return View(cinemaDetails);

        }

        public async Task<IActionResult> Edit(int id)
        {
            var query = new GetCinemaById { Id = id };
            var newGetCinemaByIdValidator = new GetCinemaByIdValidator(id);
            var result = await newGetCinemaByIdValidator.ValidateAsync(query);

            if (!result.IsValid)
            {
                return RedirectToAction(nameof(NotFound));
            }
            var cinema = await _cinemaService.Send(query);

            if (cinema == null)
            {
                return RedirectToAction(nameof(Index));

            }
            return View(cinema);

        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Cinema cinema)

        {
            CinemaValidator cinemaValidator = new CinemaValidator();
            ValidationResult result = await cinemaValidator.ValidateAsync(cinema);
            if (!result.IsValid)
            {
                foreach (var failure in result.Errors)
                {
                    //ModelState.AddModelError(failure.ErrorCode, failure.ErrorMessage);
                    ModelState.AddModelError(failure.PropertyName, failure.ErrorMessage);
                }
                return View(cinema);
            }

            await _cinemaService.Send(new UpdateCinema { Id = id, cinema = cinema });

            return RedirectToAction(nameof(Index));

        }
        public async Task<IActionResult> Delete(int id)
        {
            var query = new GetCinemaById { Id = id };
            var newGetCinemaById = new GetCinemaByIdValidator(id);
            var result = await newGetCinemaById.ValidateAsync(query);

            if (!result.IsValid)
            {
                return RedirectToAction(nameof(Index));
            }
            var cinemaDetails = await _cinemaService.Send(query);

            if (cinemaDetails == null)
            {
                return RedirectToAction(nameof(NotFound));

            }
            return View(cinemaDetails);

        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)

        {
            await _cinemaService.Send(new DeleteCinema { Id = id });

            return View("NotFound");

        }

    }
}
