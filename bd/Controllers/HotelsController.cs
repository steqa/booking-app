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
    public class HotelsController : ControllerBase
    {
        private readonly MyDbContext _context;

        public HotelsController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/Hotels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HotelSchemas.SHotelExtended>>> GetHotels()
        {
            var hotels = await _context.Hotels.ToHotelExtended().ToListAsync();

            return Ok(hotels);
        }

        // GET: api/Hotels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HotelSchemas.SHotelExtended>> GetHotel(long id)
        {
            var hotel = await _context.Hotels.Where(h => h.Id == id).ToHotelExtended().FirstOrDefaultAsync();

            if (hotel == null)
            {
                return NotFound();
            }

            return Ok(hotel);
        }

        // PUT: api/Hotels/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHotel(long id, HotelSchemas.SHotelMinimal data)
        {
            var hotel = await _context.Hotels.FindAsync(id);

            if (hotel == null)
            {
                return NotFound();
            }

            hotel.Name = data.Name;
            hotel.Location = data.Location;
            hotel.Rating = data.Rating ?? 0;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Hotels
        [HttpPost]
        public async Task<ActionResult<HotelSchemas.SHotelExtended>> PostHotel(HotelSchemas.SHotelMinimal data)
        {
            var hotel = new Hotel
            {
                Name = data.Name,
                Location = data.Location,
                Rating = data.Rating ?? 0,
            };
            _context.Hotels.Add(hotel);
            await _context.SaveChangesAsync();

            return await GetHotel(hotel.Id);
        }

        // DELETE: api/Hotels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotel(long id)
        {
            var hotel = await _context.Hotels.FindAsync(id);

            if (hotel == null)
            {
                return NotFound();
            }

            _context.Hotels.Remove(hotel);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
