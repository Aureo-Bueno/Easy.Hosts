using Easy.Hosts.Core.DTOs.Booking;
using Easy.Hosts.Core.Events;
using Easy.Hosts.Core.Repositories.Interface;
using Easy.Hosts.Core.Validators.Booking;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Easy.Hosts.Controllers
{
    [Route("api/easyhosts/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly ILogger<BookingController> _logger;
        public BookingController(IBookingRepository bookingRepository, ILogger<BookingController> logger)
        {
            _bookingRepository = bookingRepository;
            _logger = logger;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok();
        }

        [HttpGet("id:guid")]
        public async Task<IActionResult> GetById()
        {
            return Ok();
        }

        [HttpGet("id:string")]
        public async Task<IActionResult> GetBookingByUserId([FromRoute] string id)
        {
            List<BookingReadDto> result = await _bookingRepository.GetBookingByUserIdAsync(id);
            _logger.LogInformation(MyLogEvents.GetItem, $"Get Booking by UserId: {id}");
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] BookingCreateDto bookingCreatedDto)
        {
            BookingCreateDtoValidator validator = new();
            ValidationResult validate = await validator.ValidateAsync(bookingCreatedDto);

            if (validate.IsValid) 
            {
                await _bookingRepository.InsertAsync(bookingCreatedDto);
                _logger.LogInformation(MyLogEvents.InsertItem, $"Inserted Booking");
                return Ok();
            }

            return BadRequest(validate.Errors);
        }

        [HttpPut("id:guid")]
        public async Task<IActionResult> Update()
        {
            return Ok();
        }

        [HttpDelete("id:guid")]
        public async Task<IActionResult> Delete()
        {
            return Ok();
        }
    }
}
