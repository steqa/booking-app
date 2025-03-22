using backend.Exceptions;

namespace backend.Schemas.Booking;

public class SBookingUpdate
{
    public long GuestId { get; }
    public long RoomId { get; }
    public DateTime CheckIn { get; }
    public DateTime CheckOut { get; }

    public SBookingUpdate(long guestId, long roomId, DateTime checkIn, DateTime checkOut)
    {
        GuestId = guestId;
        RoomId = roomId;
        CheckIn = checkIn;
        CheckOut = checkOut;
        
        _validate();
    }

    private void _validate()
    {
        var guestIdErrors = Validator.ValidateGuestId(GuestId);
        var roomIdErrors = Validator.ValidateRoomId(RoomId);
        
        var errors = new Dictionary<string, List<string>>();

        if (guestIdErrors.Count > 0)
            errors.Add("guestId", guestIdErrors);
        if (roomIdErrors.Count > 0)
            errors.Add("roomId", roomIdErrors);

        if (errors.Count != 0)
            throw new EHttpValidation(errors);
    }
}