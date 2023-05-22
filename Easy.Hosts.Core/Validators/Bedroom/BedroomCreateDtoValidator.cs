using Easy.Hosts.Core.DTOs.BedroomDto;
using FluentValidation;

namespace Easy.Hosts.Core.Validators.Bedroom
{
    public class BedroomCreateDtoValidator : AbstractValidator<BedroomCreateDto>
    {
        public BedroomCreateDtoValidator()
        {
            RuleFor(bedroomCreate => bedroomCreate.Name).NotEmpty().WithMessage("Nome não pode ser vázio");
            RuleFor(bedroomCreate => bedroomCreate.Number).NotEmpty().WithMessage("Número não pode ser vázio");
        }
    }
}
