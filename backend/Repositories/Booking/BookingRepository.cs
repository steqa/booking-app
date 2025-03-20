using backend.Data;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories.Booking;

public class BookingRepository : IBookingRepository
{
    private readonly MyDbContext _context;

    public BookingRepository(MyDbContext context)
    {
        _context = context;
    }
    
    public async Task<Models.Booking> CreateBooking(Models.Booking booking)
    {
        await _context.Bookings.AddAsync(booking);
        await _context.SaveChangesAsync();
        return booking;
    }

    public async Task<Models.Booking?> GetBooking(BookingFilter? filter)
    {
        IQueryable<Models.Booking> query = _context.Bookings;
        if (filter != null)
        {
            if (filter.Id.HasValue)
            {
                query = query.Where(b => b.Id == filter.Id);
            }
        }
        return await query.FirstOrDefaultAsync();
    }
    
    public async Task<Models.Booking[]> GetBookings()
    {
        return await _context.Bookings.ToArrayAsync();
    }
    
    public async Task<Models.Booking> UpdateBooking(Models.Booking booking)
    {
        _context.Bookings.Update(booking);
        await _context.SaveChangesAsync();
        return booking;
    }

    public async Task DeleteBooking(long id)
    {
        await _context.Bookings
            .Where(b => b.Id == id)
            .ExecuteDeleteAsync();
    }
}