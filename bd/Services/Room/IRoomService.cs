using bd.Schemas.Hotel;
using bd.Schemas.Room;

namespace bd.Services.Room;

public interface IRoomService
{
    Task<SRoomResponse> CreateRoom(SRoomCreate data);
    Task<SRoomResponse?> GetRoom(long id);
    Task<SRoomResponse[]> GetRooms();
    Task<SRoomBookingsResponse[]> GetRoomsBookings();
    Task<SRoomResponse?> UpdateRoom(long id, SRoomUpdate data);
    Task DeleteRoom(long id);
}