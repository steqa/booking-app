using backend.Exceptions;

namespace backend.Schemas.Room;

public class SRoomCreate
{
    public long HotelId { get; }
    public string RoomNumber { get; }
    public long PricePerDay { get; }
    public bool? IsAvailable { get; }

    public SRoomCreate(long hotelId, string roomNumber, long pricePerDay, bool? isAvailable)
    {
        HotelId = hotelId;
        RoomNumber = roomNumber;
        PricePerDay = pricePerDay;
        IsAvailable = isAvailable ?? true;
        
        var hotelIdErrors = new List<string>();
        if (HotelId < 1)
            hotelIdErrors.Add("Hotel Id must be greater than or equal to 1.");
        
        var roomNumberErrors = new List<string>();
        if (string.IsNullOrWhiteSpace(RoomNumber))
            roomNumberErrors.Add("Room Number is required.");
        else
            if (RoomNumber.Length > 10)
                roomNumberErrors.Add("Room Number cannot be longer than 10 characters.");
        
        var pricePerDayErrors = new List<string>();
        if (PricePerDay < 0)
            pricePerDayErrors.Add("Price Per Day must be greater than or equal to 0.");

        var errors = new Dictionary<string, List<string>>();

        if (hotelIdErrors.Count > 0)
            errors.Add("hotelId", hotelIdErrors);
        if (roomNumberErrors.Count > 0)
            errors.Add("roomNumber", roomNumberErrors);
        if (pricePerDayErrors.Count > 0)
            errors.Add("pricePerDay", pricePerDayErrors);

        if (errors.Count != 0)
            throw new EHttpValidation(errors);
    }
}