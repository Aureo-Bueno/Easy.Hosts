using Easy.Hosts.Core.DTOs.Booking;
using Easy.Hosts.Core.Events;
using Easy.Hosts.Core.Repositories.Interface;
using Microsoft.AspNetCore.Authorization;
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
            await _bookingRepository.InsertAsync(bookingCreatedDto);
            return Ok();
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
