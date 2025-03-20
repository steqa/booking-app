using backend.Exceptions.Hotel;
using backend.Repositories.Hotel;
using backend.Schemas.Hotel;

namespace backend.Services.Hotel;

public class HotelService : IHotelService
{
    private readonly IHotelRepository _hotelRepository;

    public HotelService(IHotelRepository hotelRepository)
    {
        _hotelRepository = hotelRepository;
    }

    public async Task<SHotelResponse> CreateHotel(SHotelCreate data)
    {
        var hotel = await _hotelRepository.CreateHotel(new Models.Hotel
        {
            Name = data.Name,
            Location = data.Location,
            Rating = data.Rating ?? 0,
        });
        
        return new SHotelResponse(hotel);
    }
    
    public async Task<SHotelResponse> GetHotel(long id)
    {
        var hotel = await _hotelRepository.GetHotel(new HotelFilter { Id = id });
        if (hotel == null)
            throw new EHttpHotelNotFound();

        return new SHotelResponse(hotel);
    }
    
    public async Task<SHotelResponse[]> GetHotels()
    {
        var hotels = await _hotelRepository.GetHotels();
        
        return hotels.Select(hotel => new SHotelResponse(hotel)).ToArray();
    }
    
    public async Task<SHotelRoomsResponse[]> GetHotelsRooms()
    {
        var hotels = await _hotelRepository.GetHotelsRooms();
        
        return hotels.Select(hotel => new SHotelRoomsResponse(hotel)).ToArray();
    }

    public async Task<SHotelResponse> UpdateHotel(long id, SHotelUpdate data)
    {
        var hotel = await _hotelRepository.GetHotel(new HotelFilter { Id = id });
        if (hotel == null)
            throw new EHttpHotelNotFound();
        
        hotel.Name = data.Name;
        hotel.Location = data.Location;
        hotel.Rating = data.Rating ?? 0;
        
        hotel = await _hotelRepository.UpdateHotel(hotel);
        
        return new SHotelResponse(hotel);
    }

    public async Task DeleteHotel(long id)
    {
        var hotel = await _hotelRepository.GetHotel(new HotelFilter { Id = id });
        if (hotel == null)
            throw new EHttpHotelNotFound();
        
        await _hotelRepository.DeleteHotel(id);
    }
}