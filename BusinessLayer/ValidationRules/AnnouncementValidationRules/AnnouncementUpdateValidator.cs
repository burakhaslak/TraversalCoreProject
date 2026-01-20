using DTOLayer.DTOs.AnnouncementDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.AnnouncementValidationRules
{
    public class AnnouncementUpdateValidator : AbstractValidator<AnnouncementUpdateDTO>
    {
        public AnnouncementUpdateValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Please don't leave this field empty.");
            RuleFor(x => x.Content).NotEmpty().WithMessage("Please don't leave this field empty.");
            RuleFor(x => x.Title).MinimumLength(5).WithMessage("Please write at least 5 characters");
            RuleFor(x => x.Content).MinimumLength(20).WithMessage("Please write at least 20 characters");
            RuleFor(x => x.Title).MaximumLength(50).WithMessage("Please write at most 50 characters");
            RuleFor(x => x.Content).MaximumLength(500).WithMessage("Please write at most 500 characters");
        }
    }
}
