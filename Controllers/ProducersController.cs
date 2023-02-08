using Ecommerce.Data;
using Ecommerce.Data.RequestHandlers.ProducerRequestHandler;
using Ecommerce.Models.Validators.ProducerValidator;
using Ecommerce.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FluentValidation.Results;
namespace Ecommerce.Controllers
   {
    public class ProducersController : Controller
    {
        
        private readonly ISender _producerService;
        public ProducersController(ISender producerService)
        {
            _producerService = producerService;

        }
       
        public async  Task<IActionResult> Index()
        {
            var producers = await _producerService.Send(new GetProducer());
            return View(producers);
        }

        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Producer prod)

        {
            ProducerValidator producerValidator = new ProducerValidator();
            ValidationResult result = await producerValidator.ValidateAsync(prod);
            if (!result.IsValid)
            {
                foreach (var failure in result.Errors)
                {
                    //ModelState.AddModelError(failure.ErrorCode, failure.ErrorMessage);
                    ModelState.AddModelError(failure.PropertyName, failure.ErrorMessage);
                }
                return View(prod);
            }

            await _producerService.Send(new AddProucer { producer = prod});

            return RedirectToAction(nameof(Index));

        }


        public async Task<IActionResult> Details(int id)
        {
            var getProd = new GetProducerById { Id = id };
            
            

            
            var producerDetails = await _producerService.Send(getProd);

            if (producerDetails == null)
            {
                return RedirectToAction(nameof(Index));

            }
            return View(producerDetails);

        }

        public async Task<IActionResult> Edit(int id)
        {
            var query = new GetProducerById { Id = id };
            var newGetProducerByIdValidator = new GetProducerByIdValidator(id);
            var result = await newGetProducerByIdValidator.ValidateAsync(query);

            if (!result.IsValid)
            {
                return RedirectToAction(nameof(NotFound));
            }
            var producer = await _producerService.Send(query);

            if (producer == null)
            {
                return RedirectToAction(nameof(Index));

            }
            return View(producer);

        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Producer producer)

        {
            ProducerValidator producerValidator = new ProducerValidator();
            ValidationResult result = await producerValidator.ValidateAsync(producer);
            if (!result.IsValid)
            {
                foreach (var failure in result.Errors)
                {
                    //ModelState.AddModelError(failure.ErrorCode, failure.ErrorMessage);
                    ModelState.AddModelError(failure.PropertyName, failure.ErrorMessage);
                }
                return View(producer);
            }

            await _producerService.Send(new UpdateProducer { Id = id, producer = producer });

            return RedirectToAction(nameof(Index));

        }
        public async Task<IActionResult> Delete(int id)
        {
            var query = new GetProducerById { Id = id };
            var newGetProducerById = new GetProducerByIdValidator(id);
            var result = await newGetProducerById.ValidateAsync(query);

            if (!result.IsValid)
            {
                return RedirectToAction(nameof(Index));
            }
            var producerDetails = await _producerService.Send(query);

            if (producerDetails == null)
            {
                return RedirectToAction(nameof(NotFound));

            }
            return View(producerDetails);

        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)

        {
            await _producerService.Send(new DeleteProducer { Id = id });

            return View("NotFound");

        }
    }
}
