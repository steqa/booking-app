namespace bd.Repositories.Hotel;

public interface IHotelRepository
{
    Task<Models.Hotel> CreateHotel(Models.Hotel guest);
    Task<Models.Hotel?> GetHotel(HotelFilter? filters = null);
    Task<Models.Hotel[]> GetHotels();
    Task<Models.Hotel[]> GetHotelsRooms();
    Task<Models.Hotel> UpdateHotel(Models.Hotel guest);
    Task DeleteHotel(long id);
}