using backend.Exceptions;

namespace backend.Schemas.Booking;

public class SBookingCreate
{
    public long GuestId { get; }
    public long RoomId { get; }
    public DateTime CheckIn { get; }
    public DateTime CheckOut { get; }

    public SBookingCreate(long guestId, long roomId, DateTime checkIn, DateTime checkOut)
    {
        GuestId = guestId;
        RoomId = roomId;
        CheckIn = checkIn;
        CheckOut = checkOut;
        
        var guestIdErrors = new List<string>();
        if (GuestId < 1)
            guestIdErrors.Add("Guest Id must be greater than or equal to 1.");
        
        var roomIdErrors = new List<string>();
        if (RoomId < 1)
            roomIdErrors.Add("Room Id must be greater than or equal to 1.");
        
        var errors = new Dictionary<string, List<string>>();

        if (guestIdErrors.Count > 0)
            errors.Add("guestId", guestIdErrors);
        if (roomIdErrors.Count > 0)
            errors.Add("roomId", roomIdErrors);

        if (errors.Count != 0)
            throw new EHttpValidation(errors);
    }
}