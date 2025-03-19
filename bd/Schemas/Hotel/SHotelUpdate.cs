using bd.Exceptions;

namespace bd.Schemas.Hotel;

public class SHotelUpdate
{
    public string Name { get; }
    public string Location { get; }
    public decimal? Rating { get; }

    public SHotelUpdate(string name, string location, decimal? rating)
    {
        Name = name;
        Location = location;
        Rating = rating ?? 0;

        var nameErrors = new List<string>();
        if (string.IsNullOrWhiteSpace(Name))
            nameErrors.Add("Name is required.");
        else
            if (Name.Length > 255)
                nameErrors.Add("Name cannot be longer than 255 characters.");
        
        var locationErrors = new List<string>();
        if (string.IsNullOrWhiteSpace(Location))
            locationErrors.Add("Location is required.");
        else
            if (Location.Length > 255)
                locationErrors.Add("Location cannot be longer than 255 characters.");
        
        var ratingErrors = new List<string>();
        if (rating < 0 || rating > 5)
            ratingErrors.Add("Rating must be between 0 and 5.");

        var errors = new Dictionary<string, List<string>>();

        if (nameErrors.Count > 0)
            errors.Add("name", nameErrors);
        if (locationErrors.Count > 0)
            errors.Add("location", locationErrors);
        if (ratingErrors.Count > 0)
            errors.Add("rating", ratingErrors);

        if (errors.Count != 0)
            throw new EValidation(errors);
    }
}