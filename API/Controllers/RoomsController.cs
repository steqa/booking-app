using backend.Schemas.Room;
using backend.Services.Room;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/rooms")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly IRoomService _roomService;

        public RoomsController(IRoomService roomService)
        {
            _roomService = roomService;
        }
        
        [HttpPost]
        public async Task<ActionResult<SRoomResponse>> PostRoom(SRoomCreate data)
        {
            var room = await _roomService.CreateRoom(data);
            return CreatedAtAction(nameof(GetRoom), new { id = room.Id }, room);
        }

        [HttpGet]
        public async Task<ActionResult<SRoomResponse[]>> GetRooms()
        {
            var rooms = await _roomService.GetRooms();
            return Ok(rooms);
        }
        
        [HttpGet("bookings")]
        public async Task<ActionResult<SRoomBookingsResponse[]>> GetRoomsBookings()
        {
            var rooms = await _roomService.GetRoomsBookings();
            return Ok(rooms);
        }
        
        [HttpGet("{id:long}")]
        public async Task<ActionResult<SRoomResponse>> GetRoom(long id)
        {
            var room = await _roomService.GetRoom(id);
            return Ok(room);
        }

        [HttpPut("{id:long}")]
        public async Task<ActionResult<SRoomResponse>> PutRoom(long id, SRoomUpdate data)
        {
            var room = await _roomService.UpdateRoom(id, data);
            return Ok(room);
        }

        [HttpDelete("{id:long}")]
        public async Task<ActionResult> DeleteRoom(long id)
        {
            await _roomService.DeleteRoom(id);
            return NoContent();
        }
    }
}
