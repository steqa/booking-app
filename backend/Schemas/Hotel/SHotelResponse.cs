using System.Diagnostics.CodeAnalysis;

namespace backend.Schemas.Hotel;

public class SHotelResponse
{
    public required long Id { get; set; }
    public required string Name { get; set; }
    public required string Location { get; set; }
    public required decimal Rating { get; set; }

    [SetsRequiredMembers]
    public SHotelResponse(Models.Hotel hotel)
    {
        Id = hotel.Id;
        Name = hotel.Name;
        Location = hotel.Location;
        Rating = hotel.Rating;
    }
}