using Easy.Hosts.Core.DTOs.BookingDto;
using FluentValidation;

namespace Easy.Hosts.Core.Validators.Booking
{
    public class BookingCreateDtoValidator : AbstractValidator<BookingCreateDto>
    {
        public BookingCreateDtoValidator()
        {
            RuleFor(bookingCreate => bookingCreate.UserId).NotEmpty().WithMessage("Usuário não pode ser vázio");
            RuleFor(bookingCreate => bookingCreate.TotalValue).NotEmpty().WithMessage("ValorTotal não pode ser vázio");
            RuleFor(bookingCreate => bookingCreate.Checkin).NotEmpty().WithMessage("Checkin não pode ser vázio");
            RuleFor(bookingCreate => bookingCreate.Checkout).NotEmpty().WithMessage("Checkout não pode ser vázio");
            RuleFor(bookingCreate => bookingCreate.BedroomId).NotEmpty().WithMessage("Quarto não pode ser vázio");
        }
    }
}
