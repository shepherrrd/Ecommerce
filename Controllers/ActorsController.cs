using Ecommerce.Data;
using Ecommerce.Data.RequestHandlers.ActorsRequestHandlers;
using Ecommerce.Data.Services;
using Ecommerce.Models;
using Ecommerce.Models.Validators;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Ecommerce.Controllers
{
    public class ActorsController : Controller
    {
        private readonly ISender _actorsService;
        public ActorsController(ISender actorsService)
        {
            _actorsService = actorsService;

        }
        public async Task<IActionResult> Index()
        {
            var response = await _actorsService.Send(new GetActors());



            return View(response);
        }

        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Actors actor)

        {
            ActorValidator actorsValidator = new ActorValidator();
            ValidationResult result = await actorsValidator.ValidateAsync(actor);
            if (!result.IsValid)
            {
                foreach (var failure in result.Errors)
                {
                    //ModelState.AddModelError(failure.ErrorCode, failure.ErrorMessage);
                    ModelState.AddModelError(failure.PropertyName, failure.ErrorMessage);
                }
                return View(actor);
            }

            await _actorsService.Send(actor);

            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Details(int id)
        {
            var query = new GetActorById { Id = id };
            var newGetActorByIdValidator = new GetActorByIdValidator(id);
            var result = await newGetActorByIdValidator.ValidateAsync(query);

            if (!result.IsValid)
            {
                return RedirectToAction(nameof(Index));
            }
            var actorDetails = await _actorsService.Send(query);

            if(actorDetails == null) {
                return RedirectToAction(nameof(Index));

            }
            return View(actorDetails);

        }
        public async Task<IActionResult> Edit(int id)
        {
            var query = new GetActorById { Id = id };
            var newGetActorByIdValidator = new GetActorByIdValidator(id);
            var result = await newGetActorByIdValidator.ValidateAsync(query);

            if (!result.IsValid)
            {
                return RedirectToAction(nameof(NotFound));
            }
            var actorDetails = await _actorsService.Send(query);

            if (actorDetails == null)
            {
                return RedirectToAction(nameof(Index));

            }
            return View(actorDetails);

        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id,Actors actor)

        {
            ActorValidator actorsValidator = new ActorValidator();
            ValidationResult result = await actorsValidator.ValidateAsync(actor);
            if (!result.IsValid)
            {
                foreach (var failure in result.Errors)
                {
                    //ModelState.AddModelError(failure.ErrorCode, failure.ErrorMessage);
                    ModelState.AddModelError(failure.PropertyName, failure.ErrorMessage);
                }
                return View(actor);
            }

            await _actorsService.Send(new UpdateActor { Id = id, actors = actor});

            return RedirectToAction(nameof(Index));

        }
        public async Task<IActionResult> Delete(int id)
        {
            var query = new GetActorById { Id = id };
            var newGetActorByIdValidator = new GetActorByIdValidator(id);
            var result = await newGetActorByIdValidator.ValidateAsync(query);

            if (!result.IsValid)
            {
                return RedirectToAction(nameof(Index));
            }
            var actorDetails = await _actorsService.Send(query);

            if (actorDetails == null)
            {
                return RedirectToAction(nameof(NotFound));

            }
            return View(actorDetails);

        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)

        {
            
            

            await _actorsService.Send(new DeleteActor { Id = id });

            return RedirectToAction(nameof(NotFound));

        }
    }
}
