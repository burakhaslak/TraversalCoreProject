using DTOLayer.DTOs.ContactDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.ContactUs
{
    public class SendContactUsValidator : AbstractValidator<SendMessageDto>
    {
        public SendContactUsValidator()
        {
            RuleFor(x => x.Mail).NotEmpty().WithMessage("You can't leave this field empty.");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("You can't leave this field empty.");
            RuleFor(x => x.Name).NotEmpty().WithMessage("You can't leave this field empty.");
            RuleFor(x => x.MessageBody).NotEmpty().WithMessage("You can't leave this field empty.");
            RuleFor(x => x.Subject).MinimumLength(5).WithMessage("You should write at least 5 characters.");
            RuleFor(x => x.Subject).MaximumLength(100).WithMessage("You should write at most 100 characters.");
            RuleFor(x => x.Mail).MinimumLength(5).WithMessage("You should write at least 5 characters.");
            RuleFor(x => x.Mail).MaximumLength(100).WithMessage("You should write at most 100 characters.");
        }
    }
}
