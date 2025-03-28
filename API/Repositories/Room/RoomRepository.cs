using backend.Data;
using backend.Filters;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories.Room;

public class RoomRepository : IRoomRepository
{
    private readonly AppDbContext _context;

    public RoomRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<Models.Room> CreateRoom(Models.Room room)
    {
        await _context.Rooms.AddAsync(room);
        await _context.SaveChangesAsync();
        return room;
    }

    public async Task<Models.Room?> GetRoom(RoomFilter? filter)
    {
        IQueryable<Models.Room> query = _context.Rooms;
        if (filter != null)
        {
            if (filter.Id.HasValue)
            {
                query = query.Where(r => r.Id == filter.Id);
            }
        }
        return await query.FirstOrDefaultAsync();
    }
    
    public async Task<Models.Room[]> GetRooms(RoomFilter? filter)
    {
        IQueryable<Models.Room> query = _context.Rooms;
        if (filter != null)
        {
            if (filter.Id.HasValue)
            {
                query = query.Where(r => r.Id == filter.Id);
            }

            if (filter.hotelId.HasValue)
            {
                query = query.Where(r => r.HotelId == filter.hotelId);
            }
        }
        return await query.ToArrayAsync();
    }

    public async Task<Models.Room[]> GetRoomsBookings()
    {
        return await _context.Rooms.Include(room => room.Bookings).ToArrayAsync();
    }
    
    public async Task<Models.Room> UpdateRoom(Models.Room room)
    {
        _context.Rooms.Update(room);
        await _context.SaveChangesAsync();
        return room;
    }

    public async Task DeleteRoom(long id)
    {
        await _context.Rooms
            .Where(r => r.Id == id)
            .ExecuteDeleteAsync();
    }
}