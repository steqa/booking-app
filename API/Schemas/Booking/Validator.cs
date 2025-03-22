namespace backend.Schemas.Booking;

public static class Validator
{
    public static List<string> ValidateGuestId(long guestId)
    {
        var errors = new List<string>();
        if (guestId < 1)
            errors.Add("Guest Id must be greater than or equal to 1.");
        return errors;
    }
    
    public static List<string> ValidateRoomId(long roomId)
    {
        var errors = new List<string>();
        if (roomId < 1)
            errors.Add("Room Id must be greater than or equal to 1.");
        return errors;
    }
}