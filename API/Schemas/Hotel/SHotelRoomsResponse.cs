using System.Diagnostics.CodeAnalysis;

namespace backend.Schemas.Hotel;

public class SHotelRoomsResponse
{
    public required long Id { get; set; }
    public required string Name { get; set; }
    public required string Location { get; set; }
    public required decimal Rating { get; set; }
    public List<SHotelRoomsResponseRoom> Rooms { get; set; }

    public class SHotelRoomsResponseRoom
    {
        public required long Id { get; set; }
        public required string RoomNumber { get; set; }
        public required long PricePerDay { get; set; }
        public required bool IsAvailable { get; set; }
    }
    
    [SetsRequiredMembers]
    public SHotelRoomsResponse(Models.Hotel hotel)
    {
        Id = hotel.Id;
        Name = hotel.Name;
        Location = hotel.Location;
        Rating = hotel.Rating;
        Rooms = hotel.Rooms.Select(r => new SHotelRoomsResponseRoom
        {
            Id = r.Id,
            RoomNumber = r.RoomNumber,
            PricePerDay = r.PricePerDay,
            IsAvailable = r.IsAvailable
        }).ToList();
    }
}