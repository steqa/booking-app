using bd.Exceptions.Hotel;
using bd.Exceptions.Room;
using bd.Repositories.Hotel;
using bd.Repositories.Room;
using bd.Schemas.Room;

namespace bd.Services.Room;

public class RoomService : IRoomService
{
    private readonly IRoomRepository _roomRepository;
    private readonly IHotelRepository _hotelRepository;

    public RoomService(IRoomRepository roomRepository, IHotelRepository hotelRepository)
    {
        _roomRepository = roomRepository;
        _hotelRepository = hotelRepository;
    }

    public async Task<SRoomResponse> CreateRoom(SRoomCreate data)
    {
        var hotel = await _hotelRepository.GetHotel(new HotelFilter { Id = data.HotelId });
        if (hotel == null)
            throw new EHttpHotelNotFound();
        
        var room = await _roomRepository.CreateRoom(new Models.Room
        {
            HotelId = data.HotelId,
            RoomNumber = data.RoomNumber,
            PricePerDay = data.PricePerDay,
            IsAvailable = data.IsAvailable ?? true,
        });
        
        return new SRoomResponse(room);
    }
    
    public async Task<SRoomResponse?> GetRoom(long id)
    {
        var room = await _roomRepository.GetRoom(new RoomFilter { Id = id });
        if (room == null)
            throw new EHttpRoomNotFound();

        return new SRoomResponse(room);
    }
    
    public async Task<SRoomResponse[]> GetRooms()
    {
        var rooms = await _roomRepository.GetRooms();
        
        return rooms.Select(room => new SRoomResponse(room)).ToArray();
    }
    
    public async Task<SRoomBookingsResponse[]> GetRoomsBookings()
    {
        var rooms = await _roomRepository.GetRoomsBookings();
        
        return rooms.Select(room => new SRoomBookingsResponse(room)).ToArray();
    }

    public async Task<SRoomResponse?> UpdateRoom(long id, SRoomUpdate data)
    {
        var room = await _roomRepository.GetRoom(new RoomFilter { Id = id });
        if (room == null)
            throw new EHttpRoomNotFound();
        
        var hotel = await _hotelRepository.GetHotel(new HotelFilter { Id = data.HotelId });
        if (hotel == null)
            throw new EHttpHotelNotFound();
        
        room.HotelId = data.HotelId;
        room.RoomNumber = data.RoomNumber;
        room.PricePerDay = data.PricePerDay;
        room.IsAvailable = data.IsAvailable ?? true;
        
        room = await _roomRepository.UpdateRoom(room);
        
        return new SRoomResponse(room);
    }

    public async Task DeleteRoom(long id)
    {
        var room = await _roomRepository.GetRoom(new RoomFilter { Id = id });
        if (room == null)
            throw new EHttpRoomNotFound();
        
        await _roomRepository.DeleteRoom(id);
    }
}