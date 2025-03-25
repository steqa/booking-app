using backend.Data;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories.Guest;

public class GuestRepository : IGuestRepository
{
    private readonly AppDbContext _context;

    public GuestRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Models.Guest> CreateGuest(Models.Guest guest)
    {
        await _context.Guests.AddAsync(guest);
        await _context.SaveChangesAsync();
        return guest;
    }

    public async Task<Models.Guest?> GetGuest(GuestFilter? filter)
    {
        IQueryable<Models.Guest> query = _context.Guests;
        if (filter != null)
        {
            if (filter.Id.HasValue)
            {
                query = query.Where(g => g.Id == filter.Id);
            }
            if (!string.IsNullOrEmpty(filter.Email))
            {
                query = query.Where(g => g.Email == filter.Email);
            }
        }
        return await query.FirstOrDefaultAsync();
    }

    public async Task<Models.Guest[]> GetGuests()
    {
        return await _context.Guests.ToArrayAsync();
    }

    public async Task<Models.Guest> UpdateGuest(Models.Guest guest)
    {
        _context.Guests.Update(guest);
        await _context.SaveChangesAsync();
        return guest;
    }

    public async Task DeleteGuest(long id)
    {
        await _context.Guests
            .Where(g => g.Id == id)
            .ExecuteDeleteAsync();
    }
}