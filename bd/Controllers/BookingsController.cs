using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using bd.Data;
using bd.Models;
using static RoomSchemas;

namespace bd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly MyDbContext _context;

        public BookingsController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/Bookings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Booking>>> GetBookings()
        {
            var bookings = await _context.Bookings.ToBookingExtended().ToListAsync();

            return Ok(bookings);
        }

        // GET: api/Bookings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Booking>> GetBooking(long id)
        {
            var booking = await _context.Bookings.Where(b => b.Id == id).ToBookingExtended().FirstOrDefaultAsync();

            if (booking == null)
            {
                return NotFound();
            }

            return Ok(booking);
        }

        // PUT: api/Bookings/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBooking(long id, BookingSchemas.SBookingMinimal data)
        {
            var booking = await _context.Bookings.FindAsync(id);
            var guest = await _context.Guests.FindAsync(data.GuestId);
            var room = await _context.Rooms.FindAsync(data.RoomId);

            if (booking == null || guest == null || room == null)
            {
                return NotFound();
            }

            booking.GuestId = data.GuestId;
            booking.RoomId = data.RoomId;
            booking.CheckIn = data.CheckIn;
            booking.CheckOut = data.CheckOut;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Bookings
        [HttpPost]
        public async Task<ActionResult<Booking>> PostBooking(BookingSchemas.SBookingMinimal data)
        {
            var guest = await _context.Guests.FindAsync(data.GuestId);
            var room = await _context.Rooms.FindAsync(data.RoomId);

            if (guest == null || room == null)
            {
                return NotFound();
            }

            var booking = new Booking
            {
                GuestId = data.GuestId,
                RoomId = data.RoomId,
                CheckIn = data.CheckIn,
                CheckOut = data.CheckOut,
            };
            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();

            return await GetBooking(booking.Id);
        }

        // DELETE: api/Bookings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBooking(long id)
        {
            var booking = await _context.Bookings.FindAsync(id);

            if (booking == null)
            {
                return NotFound();
            }

            _context.Bookings.Remove(booking);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
