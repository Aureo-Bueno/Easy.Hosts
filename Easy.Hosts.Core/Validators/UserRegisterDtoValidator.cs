using Easy.Hosts.Core.DTOs.User;
using FluentValidation;


namespace Easy.Hosts.Core.Validators
{
    public class UserRegisterDtoValidator : AbstractValidator<UserRegisterDto>
    {
        public UserRegisterDtoValidator()
        {
            RuleFor(userRegister => userRegister.Email)
                .EmailAddress()
                .NotEmpty()
                .WithMessage("Deve ser um email e também não pode estar vázio");
            RuleFor(userRegister => userRegister.Password)
                .Length(8, 100)
                .NotEmpty()
                .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$")
                .WithMessage("Dever ter no mínimo 8 caracteres e caracteres especiais");
            RuleFor(userRegister => userRegister.ConfirmPassword)
               .Length(8, 100)
               .NotEmpty()
               .Matches(x => x.Password)
               .WithMessage("Dever ter no mínimo 8 caracteres e caracteres especiais");
            RuleFor(userRegister => userRegister.ConfirmPassword)
                .Length(8, 100)
                .Matches(userRegister => userRegister.Password)
                .WithMessage("Senhas devem ser Iguais");
            RuleFor(userRegister => userRegister.RoleName)
                .NotEmpty()
                .WithMessage("Role Inválida");
        }
    }
}
