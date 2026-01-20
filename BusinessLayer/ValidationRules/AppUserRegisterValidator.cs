using DTOLayer.DTOs.AppUserDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AppUserRegisterValidator : AbstractValidator<AppUserRegisterDTO>
    {
        public AppUserRegisterValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("You can't leave this field empty.");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("You can't leave this field empty.");
            RuleFor(x => x.Mail).NotEmpty().WithMessage("You can't leave this field empty.");
            RuleFor(x => x.Username).NotEmpty().WithMessage("You can't leave this field empty.");
            RuleFor(x => x.Password).NotEmpty().WithMessage("You can't leave this field empty.");
            RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("You can't leave this field empty.");
            RuleFor(x => x.Username).MinimumLength(5).WithMessage("You should write at least 5 characters.");
            RuleFor(x => x.Username).MaximumLength(20).WithMessage("You should write at most 20 characters.");
            RuleFor(x => x.Password).Equal(y=>y.ConfirmPassword).WithMessage("Your passwords don't match.");
        }
    }
}
