using backend.Schemas.Booking;
using backend.Services.Booking;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/bookings")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingsController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }
        
        [HttpPost]
        public async Task<ActionResult<SBookingResponse>> PostBooking(SBookingCreate data)
        {
            var booking = await _bookingService.CreateBooking(data);
            return CreatedAtAction(nameof(GetBooking), new { id = booking.Id }, booking);
        }

        [HttpGet]
        public async Task<ActionResult<SBookingResponse[]>> GetBookings()
        {
            var bookings = await _bookingService.GetBookings();
            return Ok(bookings);
        }
        
        [HttpGet("{id:long}")]
        public async Task<ActionResult<SBookingResponse>> GetBooking(long id)
        {
            var booking = await _bookingService.GetBooking(id);
            return Ok(booking);
        }

        [HttpPut("{id:long}")]
        public async Task<ActionResult<SBookingResponse>> PutBooking(long id, SBookingUpdate data)
        {
            var booking = await _bookingService.UpdateBooking(id, data);
            return Ok(booking);
        }

        [HttpDelete("{id:long}")]
        public async Task<ActionResult> DeleteRoom(long id)
        {
            await _bookingService.DeleteBooking(id);
            return NoContent();
        }
    }
}
