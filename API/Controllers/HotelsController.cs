using backend.Schemas.Hotel;
using backend.Services.Hotel;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/hotels")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly IHotelService _hotelService;

        public HotelsController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }
        
        [HttpPost]
        public async Task<ActionResult<SHotelResponse>> PostHotel(SHotelCreate data)
        {
            var hotel = await _hotelService.CreateHotel(data);
            return CreatedAtAction(nameof(GetHotel), new { id = hotel.Id }, hotel);
        }

        [HttpGet]
        public async Task<ActionResult<SHotelResponse[]>> GetHotels()
        {
            var hotels = await _hotelService.GetHotels();
            return Ok(hotels);
        }
        
        [HttpGet("rooms")]
        public async Task<ActionResult<SHotelRoomsResponse[]>> GetHotelsRooms()
        {
            var hotels = await _hotelService.GetHotelsRooms();
            return Ok(hotels);
        }
        
        [HttpGet("{id:long}")]
        public async Task<ActionResult<SHotelResponse>> GetHotel(long id)
        {
            var hotel = await _hotelService.GetHotel(id);
            return Ok(hotel);
        }

        [HttpPut("{id:long}")]
        public async Task<ActionResult<SHotelResponse>> PutHotel(long id, SHotelUpdate data)
        {
            var hotel = await _hotelService.UpdateHotel(id, data);
            return Ok(hotel);
        }

        [HttpDelete("{id:long}")]
        public async Task<ActionResult> DeleteHotel(long id)
        {
            await _hotelService.DeleteHotel(id);
            return NoContent();
        }
    }
}
