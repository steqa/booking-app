using backend.Exceptions;

namespace backend.Schemas.Room;

public class SRoomUpdate
{
    public long HotelId { get; }
    public string RoomNumber { get; }
    public long PricePerDay { get; }
    public bool? IsAvailable { get; }

    public SRoomUpdate(long hotelId, string roomNumber, long pricePerDay, bool? isAvailable)
    {
        HotelId = hotelId;
        RoomNumber = roomNumber;
        PricePerDay = pricePerDay;
        IsAvailable = isAvailable ?? true;
        
        _validate();
    }
    
    private void _validate()
    {
        var hotelIdErrors = Validator.ValidateHotelId(HotelId);
        var roomNumberErrors = Validator.ValidateRoomNumber(RoomNumber);
        var pricePerDayErrors = Validator.ValidatePricePerDay(PricePerDay);
        
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