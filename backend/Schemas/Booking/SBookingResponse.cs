using System.Diagnostics.CodeAnalysis;

namespace backend.Schemas.Booking;

public class SBookingResponse
{
    public required long Id { get; set; }
    public required long GuestId { get; set; }
    public required long RoomId { get; set; }
    public required DateTime CheckIn { get; set; }
    public required DateTime CheckOut { get; set; }

    [SetsRequiredMembers]
    public SBookingResponse(Models.Booking booking)
    {
        Id = booking.Id;
        GuestId = booking.GuestId;
        RoomId = booking.RoomId;
        CheckIn = booking.CheckIn;
        CheckOut = booking.CheckOut;
    }
}