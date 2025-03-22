using backend.Exceptions;

namespace backend.Schemas.Hotel;

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

        _validate();
    }
    
    private void _validate()
    {
        var nameErrors = Validator.ValidateName(Name);
        var locationErrors = Validator.ValidateLocation(Location);
        var ratingErrors = Validator.ValidateRating(Rating);
        
        var errors = new Dictionary<string, List<string>>();

        if (nameErrors.Count > 0)
            errors.Add("name", nameErrors);
        if (locationErrors.Count > 0)
            errors.Add("location", locationErrors);
        if (ratingErrors.Count > 0)
            errors.Add("rating", ratingErrors);

        if (errors.Count != 0)
            throw new EHttpValidation(errors);
    }
}