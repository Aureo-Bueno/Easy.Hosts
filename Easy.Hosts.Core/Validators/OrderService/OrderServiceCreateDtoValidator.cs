using Easy.Hosts.Core.DTOs.OrderService;
using FluentValidation;

namespace Easy.Hosts.Core.Validators.OrderService
{
    public class OrderServiceCreateDtoValidator : AbstractValidator<OrderServiceCreateDto>
    {
        public OrderServiceCreateDtoValidator()
        {
            RuleFor(createOrder => createOrder.Description).NotEmpty().WithMessage("A descrição não pode ser vázio");
        }
    }
}
