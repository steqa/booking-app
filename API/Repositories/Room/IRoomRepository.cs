using backend.Filters;

namespace backend.Repositories.Room;

public interface IRoomRepository
{
    Task<Models.Room> CreateRoom(Models.Room room);
    Task<Models.Room?> GetRoom(RoomFilter? filters = null);
    Task<Models.Room[]> GetRooms(RoomFilter? filter = null);
    Task<Models.Room[]> GetRoomsBookings();
    Task<Models.Room> UpdateRoom(Models.Room room);
    Task DeleteRoom(long id);
}