using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using bd.Data;
using bd.Models;

namespace bd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly MyDbContext _context;

        public RoomsController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/Rooms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomSchemas.SRoomExtended>>> GetRooms()
        {
            var rooms = await _context.Rooms.ToRoomExtended().ToListAsync();

            return Ok(rooms);
        }

        // GET: api/Rooms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RoomSchemas.SRoomExtended>> GetRoom(long id)
        {
            var room = await _context.Rooms.Where(r => r.Id == id).ToRoomExtended().FirstOrDefaultAsync();

            if (room == null)
            {
                return NotFound();
            }

            return Ok(room);
        }

        // PUT: api/Rooms/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoom(long id, RoomSchemas.SRoomMinimal data)
        {
            var room = await _context.Rooms.FindAsync(id);
            var hotel = await _context.Hotels.FindAsync(data.HotelId);

            if (room == null || hotel == null)
            {
                return NotFound();
            }

            room.HotelId = data.HotelId;
            room.RoomNumber = data.RoomNumber;
            room.PricePerDay = data.PricePerDay;
            room.IsAvailable = data.IsAvailable ?? true;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Rooms
        [HttpPost]
        public async Task<ActionResult<RoomSchemas.SRoomExtended>> PostRoom(RoomSchemas.SRoomMinimal data)
        {
            var hotel = await _context.Hotels.FindAsync(data.HotelId);

            if (hotel == null)
            {
                return NotFound();
            }

            var room = new Room
            {
                HotelId = data.HotelId,
                RoomNumber = data.RoomNumber,
                PricePerDay = data.PricePerDay,
                IsAvailable = data.IsAvailable ?? true,
            };
            _context.Rooms.Add(room);
            await _context.SaveChangesAsync();

            return await GetRoom(room.Id);
        }

        // DELETE: api/Rooms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoom(long id)
        {
            var room = await _context.Rooms.FindAsync(id);

            if (room == null)
            {
                return NotFound();
            }
            
            var booking = await _context.Bookings.Where(b => b.RoomId == room.Id).FirstOrDefaultAsync();

            if (booking != null)
            {
                return Conflict();
            }

            _context.Rooms.Remove(room);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
