using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace Ecommerce.Models.Validators.ProducerValidator
{
    public class ProducerValidator : AbstractValidator<Producer>
    {
        public ProducerValidator()
        {
            RuleFor(m => m.FullName).NotEmpty().WithMessage("Full Name Is Required");
            RuleFor(m => m.FullName).MinimumLength(3).MaximumLength(50).WithMessage("Name Must Be between 3 And 50 Characters");
            RuleFor(m => m.ProfilePictureURL).NotEmpty().WithMessage("Profile Picture Is Required");
            RuleFor(m => m.Bio).NotEmpty().WithMessage("Bio Is Required");
        }

    }
}