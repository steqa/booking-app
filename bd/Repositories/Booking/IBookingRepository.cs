namespace bd.Repositories.Booking;

public interface IBookingRepository
{
    Task<Models.Booking> CreateBooking(Models.Booking booking);
    Task<Models.Booking?> GetBooking(BookingFilter? filters = null);
    Task<Models.Booking[]> GetBookings();
    Task<Models.Booking> UpdateBooking(Models.Booking booking);
    Task DeleteBooking(long id);
}