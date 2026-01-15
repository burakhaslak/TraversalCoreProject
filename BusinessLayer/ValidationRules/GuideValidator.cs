using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class GuideValidator : AbstractValidator<Guide>
    {
        public GuideValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Please enter a guide name");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Please enter a description for the guide");
            RuleFor(x => x.Image).NotEmpty().WithMessage("Please upload the guide's profile photo");
            RuleFor(x => x.Name).MaximumLength(30).WithMessage("Guide's name should be lower than 30 characters");
            RuleFor(x => x.Name).MinimumLength(8).WithMessage("Guide's name should be greater than 8 characters");
        }
    }
}
