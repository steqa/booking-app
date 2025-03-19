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
    public class GuestsController : ControllerBase
    {
        private readonly MyDbContext _context;

        public GuestsController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/Guests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GuestSchemas.SGuestExtended>>> GetGuests()
        {
            var guests = await _context.Guests.ToGuestExtended().ToListAsync();

            return Ok(guests);
        }

        // GET: api/Guests/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GuestSchemas.SGuestExtended>> GetGuest(long id)
        {
            var guest = await _context.Guests.Where(g => g.Id == id).ToGuestExtended().FirstOrDefaultAsync();

            if (guest == null)
            {
                return NotFound();
            }

            return Ok(guest);
        }

        // PUT: api/Guests/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGuest(long id, GuestSchemas.SGuestMinimal data)
        {
            var guest = await _context.Guests.FindAsync(id);

            if (guest == null)
            {
                return NotFound();
            }

            guest.FirstName = data.FirstName;
            guest.LastName = data.LastName;
            guest.Email = data.Email;
            guest.Phone = data.Phone;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Guests
        [HttpPost]
        public async Task<ActionResult<GuestSchemas.SGuestExtended>> PostGuest(GuestSchemas.SGuestMinimal data)
        {
            var guest = new Guest
            {
                FirstName = data.FirstName,
                LastName = data.LastName,
                Email = data.Email,
                Phone = data.Phone,
            };
            _context.Guests.Add(guest);
            await _context.SaveChangesAsync();

            return await GetGuest(guest.Id);
        }

        // DELETE: api/Guests/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGuest(long id)
        {
            var guest = await _context.Guests.FindAsync(id);

            if (guest== null)
            {
                return NotFound();
            }

            _context.Guests.Remove(guest);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
