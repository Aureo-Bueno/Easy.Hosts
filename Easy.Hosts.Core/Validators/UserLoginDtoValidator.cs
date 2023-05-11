
using Easy.Hosts.Core.DTOs.User;
using FluentValidation;

namespace Easy.Hosts.Core.Validators
{
    public class UserLoginDtoValidator : AbstractValidator<UserLoginDto>
    {
        public UserLoginDtoValidator()
        {
            RuleFor(userLogin => userLogin.Email)
                .EmailAddress()
                .WithMessage("Deve inserir o e-mail corretamente");
            RuleFor(userLogin => userLogin.Email)
                .Length(8, 100)
                .NotEmpty()
                .WithMessage("Dever ter no mínimo 8 caracteres e caracteres especiais");
        }
    }
}
