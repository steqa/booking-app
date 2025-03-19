using bd.Schemas.Hotel;

namespace bd.Services.Hotel;

public interface IHotelService
{
    Task<SHotelResponse> CreateHotel(SHotelCreate data);
    Task<SHotelResponse?> GetHotel(long id);
    Task<SHotelResponse[]> GetHotels();
    Task<SHotelRoomsResponse[]> GetHotelsRooms();
    Task<SHotelResponse?> UpdateHotel(long id, SHotelUpdate data);
    Task DeleteHotel(long id);
}