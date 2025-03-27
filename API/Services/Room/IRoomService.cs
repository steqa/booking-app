using backend.Filters;
using backend.Repositories.Room;
using backend.Schemas.Room;

namespace backend.Services.Room;

public interface IRoomService
{
    Task<SRoomResponse> CreateRoom(SRoomCreate data);
    Task<SRoomResponse> GetRoom(long id);
    Task<SRoomResponse[]> GetRooms(RoomFilter? filter);
    Task<SRoomBookingsResponse[]> GetRoomsBookings();
    Task<SRoomResponse> UpdateRoom(long id, SRoomUpdate data);
    Task DeleteRoom(long id);
}