namespace backend.Schemas.Hotel;

public static class Validator
{
    public static List<string> ValidateName(string name)
    {
        var errors = new List<string>();
        if (string.IsNullOrWhiteSpace(name))
        {
            errors.Add("Name is required.");
        }
        else
        {
            if (name.Length > 255)
                errors.Add("Name cannot be longer than 255 characters.");
        }
        return errors;
    }
    
    public static List<string> ValidateLocation(string location)
    {
        var errors = new List<string>();
        if (string.IsNullOrWhiteSpace(location))
        {
            errors.Add("Location is required.");
        }
        else
        {
            if (location.Length > 255)
                errors.Add("Location cannot be longer than 255 characters.");
        }
        return errors;
    }
 
    public static List<string> ValidateRating(decimal? rating)
    {
        var errors = new List<string>();
        if (rating < 0 || rating > 5)
            errors.Add("Rating must be between 0 and 5.");
        return errors;
    }
}