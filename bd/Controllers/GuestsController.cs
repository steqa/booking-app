using Microsoft.AspNetCore.Mvc;
using bd.Schemas.Guest;
using bd.Services.Guest;

namespace bd.Controllers
{
    [Route("api/guests")]
    [ApiController]
    public class GuestsController : ControllerBase
    {
        private readonly IGuestService _guestService;

        public GuestsController(IGuestService guestService)
        {
            _guestService = guestService;
        }

        // POST: api/Guests
        [HttpPost]
        public async Task<ActionResult<SGuestResponse>> PostGuest(SGuestCreate data)
        {
            var guest = await _guestService.CreateGuest(data);
            return CreatedAtAction(nameof(GetGuest), new { id = guest.Id }, guest);
        }
        
        // GET: api/Guests
        [HttpGet]
        public async Task<ActionResult<SGuestResponse[]>> GetGuests()
        {
            var guests = await _guestService.GetGuests();
            return Ok(guests);
        }
        
        // GET: api/Guests/5
        [HttpGet("{id:long}")]
        public async Task<ActionResult<SGuestResponse>> GetGuest(long id)
        {
            var guest = await _guestService.GetGuest(id);
            return Ok(guest);
        }

        // PUT: api/Guests/5
        [HttpPut("{id:long}")]
        public async Task<ActionResult<SGuestResponse>> PutGuest(long id, SGuestUpdate data)
        {
            var guest = await _guestService.UpdateGuest(id, data);
            return Ok(guest);
        }

        // DELETE: api/Guests/5
        [HttpDelete("{id:long}")]
        public async Task<ActionResult> DeleteGuest(long id)
        {
            await _guestService.DeleteGuest(id);
            return NoContent();
        }
    }
}
