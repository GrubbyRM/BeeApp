using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeApp.Aplication.Inspection
{
    public class InspectionValidator : AbstractValidator<BeeApp.Domain.Entities.Inspection>
    {
        public InspectionValidator()
        {
            RuleFor(c => c.CreatedAt)
                .NotEmpty().WithMessage("Data przeglądu jest wymagana"); ;
            RuleFor(c => c.BeehiveDetails.Id)
                .NotEmpty().WithMessage("Id ula jest wymagane")
                .GreaterThan(0).WithMessage("Id ula musi być liczbą INT");
            RuleFor(c => c.BeehiveDetails.BeehiveType)
                .NotEmpty().WithMessage("Typ ula jest wymagany")
                .MinimumLength(4).WithMessage("Typ ula musi mieć co najmniej 4 znaki")
                .MaximumLength(20).WithMessage("Typ ula musi mieć maksymalnie 20 znaków");
        }
    }
}
