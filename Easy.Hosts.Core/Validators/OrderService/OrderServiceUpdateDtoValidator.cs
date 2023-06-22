using Easy.Hosts.Core.DTOs.OrderServiceDto;
using FluentValidation;

namespace Easy.Hosts.Core.Validators.OrderService
{
    public class OrderServiceUpdateDtoValidator : AbstractValidator<OrderServiceUpdateDto>
    {
        public OrderServiceUpdateDtoValidator()
        {
            RuleFor(orderServiceUpdate => orderServiceUpdate.Description).NotEmpty().WithMessage("A descrição não pode ser vázia");
        }
    }
}
