namespace backend.Schemas.Room;

public static class Validator
{
    public static List<string> ValidateHotelId(long hotelId)
    {
        var errors = new List<string>();
        if (hotelId < 1)
            errors.Add("Hotel Id must be greater than or equal to 1.");
        return errors;
    }
    
    public static List<string> ValidateNumber(string number)
    {
        var errors = new List<string>();
        if (string.IsNullOrWhiteSpace(number))
        {
            errors.Add("Number is required.");
        }
        else
        {
            if (number.Length > 10)
                errors.Add("Number cannot be longer than 10 characters.");
        }
        return errors;
    }
    
    public static List<string> ValidatePricePerDay(long pricePerDay)
    {
        var errors = new List<string>();
        if (pricePerDay < 0)
            errors.Add("Price Per Day must be greater than or equal to 0.");
        return errors;
    }
}