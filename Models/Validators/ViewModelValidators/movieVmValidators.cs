using Ecommerce.Data.ViewModel;
using FluentValidation;

namespace Ecommerce.Models.Validators.ModelViewValidators
{
    public class movieVmValidators : AbstractValidator<MovieVM>
    {
        public movieVmValidators() { 
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is Required");
        RuleFor(x => x.Description).NotEmpty().WithMessage("Description is Required");
        RuleFor(x => x.Price).NotEmpty().WithMessage("Price  is Required");
        RuleFor(x => x.ImageURL).NotEmpty().WithMessage("Image Url is Required");
        RuleFor(x => x.StartDate).NotNull().WithMessage("StartDate is Required");
        RuleFor(x => x.EndDate).NotNull().WithMessage("EndDate is Required");
        RuleFor(x => x.MovieCategory).NotEmpty().WithMessage("Category is Required");
        RuleFor(x => x.CinemaId).NotEmpty().WithMessage("Cinema(s) is Required");
        RuleFor(x => x.ActorIds).NotEmpty().WithMessage("Actor(s) is Required");
        RuleFor(x => x.ProducerId).NotEmpty().WithMessage("Producer(s) is Required");

        }
    }
}
