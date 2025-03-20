using bd.Data;
using Microsoft.EntityFrameworkCore;

namespace bd.Repositories.Hotel;

public class HotelRepository : IHotelRepository
{
    private readonly MyDbContext _context;

    public HotelRepository(MyDbContext context)
    {
        _context = context;
    }

    public async Task<Models.Hotel> CreateHotel(Models.Hotel hotel)
    {
        await _context.Hotels.AddAsync(hotel);
        await _context.SaveChangesAsync();
        return hotel;
    }

    public async Task<Models.Hotel?> GetHotel(HotelFilter? filter)
    {
        IQueryable<Models.Hotel> query = _context.Hotels;
        if (filter != null)
        {
            if (filter.Id.HasValue)
            {
                query = query.Where(h => h.Id == filter.Id);
            }
        }
        return await query.FirstOrDefaultAsync();
    }
    
    public async Task<Models.Hotel[]> GetHotels()
    {
        return await _context.Hotels.ToArrayAsync();
    }

    public async Task<Models.Hotel[]> GetHotelsRooms()
    {
        return await _context.Hotels.Include(hotel => hotel.Rooms).ToArrayAsync();
    }
    
    public async Task<Models.Hotel> UpdateHotel(Models.Hotel hotel)
    {
        _context.Hotels.Update(hotel);
        await _context.SaveChangesAsync();
        return hotel;
    }

    public async Task DeleteHotel(long id)
    {
        await _context.Hotels
            .Where(h => h.Id == id)
            .ExecuteDeleteAsync();
    }
}