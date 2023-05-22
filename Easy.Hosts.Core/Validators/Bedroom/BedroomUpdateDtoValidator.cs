
using Easy.Hosts.Core.DTOs.BedroomDto;
using FluentValidation;

namespace Easy.Hosts.Core.Validators.Bedroom
{
    public class BedroomUpdateDtoValidator : AbstractValidator<BedroomUpdateDto>
    {
        public BedroomUpdateDtoValidator()
        {
            RuleFor(bedroomUpdate => bedroomUpdate.Name).NotEmpty().WithMessage("Nome não pode ser vázio");
            RuleFor(bedroomUpdate => bedroomUpdate.Number).NotEmpty().WithMessage("Número não pode ser vázio");
        }
    }
}
