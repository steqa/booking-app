using bd.Schemas.Booking;

namespace bd.Services.Booking;

public interface IBookingService
{
    Task<SBookingResponse> CreateBooking(SBookingCreate data);
    Task<SBookingResponse> GetBooking(long id);
    Task<SBookingResponse[]> GetBookings();
    Task<SBookingResponse> UpdateBooking(long id, SBookingUpdate data);
    Task DeleteBooking(long id);
}