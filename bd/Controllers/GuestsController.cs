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

        [HttpPost]
        public async Task<ActionResult<SGuestResponse>> PostGuest(SGuestCreate data)
        {
            var guest = await _guestService.CreateGuest(data);
            return CreatedAtAction(nameof(GetGuest), new { id = guest.Id }, guest);
        }
        
        [HttpGet]
        public async Task<ActionResult<SGuestResponse[]>> GetGuests()
        {
            var guests = await _guestService.GetGuests();
            return Ok(guests);
        }
        
        [HttpGet("{id:long}")]
        public async Task<ActionResult<SGuestResponse>> GetGuest(long id)
        {
            var guest = await _guestService.GetGuest(id);
            return Ok(guest);
        }

        [HttpPut("{id:long}")]
        public async Task<ActionResult<SGuestResponse>> PutGuest(long id, SGuestUpdate data)
        {
            var guest = await _guestService.UpdateGuest(id, data);
            return Ok(guest);
        }

        [HttpDelete("{id:long}")]
        public async Task<ActionResult> DeleteGuest(long id)
        {
            await _guestService.DeleteGuest(id);
            return NoContent();
        }
    }
}
