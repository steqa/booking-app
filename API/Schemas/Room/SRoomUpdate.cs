using backend.Exceptions;

namespace backend.Schemas.Room;

public class SRoomUpdate
{
    public long HotelId { get; }
    public string Number { get; }
    public long PricePerDay { get; }
    public bool? IsAvailable { get; }

    public SRoomUpdate(long hotelId, string number, long pricePerDay, bool? isAvailable)
    {
        HotelId = hotelId;
        Number = number;
        PricePerDay = pricePerDay;
        IsAvailable = isAvailable ?? true;
        
        _validate();
    }
    
    private void _validate()
    {
        var hotelIdErrors = Validator.ValidateHotelId(HotelId);
        var numberErrors = Validator.ValidateNumber(Number);
        var pricePerDayErrors = Validator.ValidatePricePerDay(PricePerDay);
        
        var errors = new Dictionary<string, List<string>>();

        if (hotelIdErrors.Count > 0)
            errors.Add("hotelId", hotelIdErrors);
        if (numberErrors.Count > 0)
            errors.Add("roomNumber", numberErrors);
        if (pricePerDayErrors.Count > 0)
            errors.Add("pricePerDay", pricePerDayErrors);

        if (errors.Count != 0)
            throw new EHttpValidation(errors);
    }
}