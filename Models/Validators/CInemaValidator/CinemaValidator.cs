using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace Ecommerce.Models.Validators.CinemaValidator
{
    public class CinemaValidator : AbstractValidator<Cinema>
    {
        public CinemaValidator()
        {
            RuleFor(m => m.Name).NotEmpty().WithMessage("Full Name Is Required");
            RuleFor(m => m.Name).MinimumLength(3).MaximumLength(50).WithMessage("Name Must Be between 3 And 50 Characters");
            RuleFor(m => m.Logo).NotEmpty().WithMessage("Profile Picture Is Required");
            RuleFor(m => m.Description).NotEmpty().WithMessage("Bio Is Required");
        }

    }
}