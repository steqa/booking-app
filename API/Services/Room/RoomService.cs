using backend.Exceptions.Room;
using backend.Filters;
using backend.Repositories.Room;
using backend.Schemas.Room;
using backend.Services.Hotel;

namespace backend.Services.Room;

public class RoomService : IRoomService
{
    private readonly IRoomRepository _roomRepository;
    private readonly IHotelService _hotelService;

    public RoomService(IRoomRepository roomRepository, IHotelService hotelService)
    {
        _roomRepository = roomRepository;
        _hotelService = hotelService;
    }

    public async Task<SRoomResponse> CreateRoom(SRoomCreate data)
    {
        var hotel = await _hotelService.GetHotel(data.HotelId);
        
        var room = await _roomRepository.CreateRoom(new Models.Room
        {
            HotelId = hotel.Id,
            Number = data.Number,
            PricePerDay = data.PricePerDay,
            IsAvailable = data.IsAvailable ?? true,
        });
        
        return new SRoomResponse(room);
    }
    
    public async Task<SRoomResponse> GetRoom(long id)
    {
        var room = await _roomRepository.GetRoom(new RoomFilter { Id = id });
        if (room == null)
            throw new EHttpRoomNotFound();

        return new SRoomResponse(room);
    }
    
    public async Task<SRoomResponse[]> GetRooms(RoomFilter? filter)
    {
        var rooms = await _roomRepository.GetRooms(filter);
        
        return rooms.Select(room => new SRoomResponse(room)).ToArray();
    }
    
    public async Task<SRoomBookingsResponse[]> GetRoomsBookings()
    {
        var rooms = await _roomRepository.GetRoomsBookings();
        
        return rooms.Select(room => new SRoomBookingsResponse(room)).ToArray();
    }

    public async Task<SRoomResponse> UpdateRoom(long id, SRoomUpdate data)
    {
        var room = await _roomRepository.GetRoom(new RoomFilter { Id = id });
        if (room == null)
            throw new EHttpRoomNotFound();
        
        var hotel = await _hotelService.GetHotel(data.HotelId);
        
        room.HotelId = hotel.Id;
        room.Number = data.Number;
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