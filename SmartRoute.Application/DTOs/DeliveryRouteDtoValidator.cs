using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartRoute.Application.DTOs
{
    public class DeliveryRouteDtoValidator : AbstractValidator<DeliveryRouteDto>
    {
        public DeliveryRouteDtoValidator()
        {
            RuleFor(x => x.OriginIbgeCode)
                .NotEmpty().WithMessage("Origin IBGE code is required.")
                .Length(7).WithMessage("IBGE code must have exactly 7 digits.");

            RuleFor(x => x.DestinationIbgeCode)
                .NotEmpty().WithMessage("Destination IBGE code is required.")
                .Length(7).WithMessage("IBGE code must have exactly 7 digits.");

            RuleFor(x => x.Origin)
                .NotEmpty().WithMessage("Origin is required.");

            RuleFor(x => x.Destination)
                .NotEmpty().WithMessage("Destination is required.");
        }
    }
}
