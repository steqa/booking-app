using bd.Data;
using Microsoft.EntityFrameworkCore;

namespace bd.Repositories.Room;

public class RoomRepository : IRoomRepository
{
    private readonly MyDbContext _context;

    public RoomRepository(MyDbContext context)
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
    
    public async Task<Models.Room[]> GetRooms()
    {
        return await _context.Rooms.ToArrayAsync();
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