using Easy.Hosts.Core.DTOs.User;
using FluentValidation;

namespace Easy.Hosts.Core.Validators
{
    public class ChangePasswordDtoValidator : AbstractValidator<ChangePasswordDto>
    {
        public ChangePasswordDtoValidator()
        {
            RuleFor(changePassword => changePassword.CurrentPassword)
               .NotEmpty()
               .NotNull()
               .Length(8,100)
               .WithMessage("A senha deve conter no minímo 8 caracteres incluindo caractesres especiais");

            RuleFor(changePassoword => changePassoword.NewPassword)
               .NotEmpty()
               .NotNull()
               .Length(8, 100)
               .WithMessage("A senha deve conter no minímo 8 caracteres incluindo caractesres especiais");
        }
    }
}
