using Easy.Hosts.Core.DTOs.User;
using FluentValidation;


namespace Easy.Hosts.Core.Validators
{
    public class UserRegisterDtoValidator : AbstractValidator<UserRegisterDto>
    {
        public UserRegisterDtoValidator()
        {
            RuleFor(userRegister => userRegister.Email).EmailAddress().NotEmpty().WithMessage("Deve ser um email e também não pode estar vázio");
            RuleFor(userRegister => userRegister.Password).Length(8, 100).NotEmpty().WithMessage("Dever ter no mínimo 8 caracteres e caracteres especiais");
        }
    }
}
