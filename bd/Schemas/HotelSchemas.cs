using bd.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

public static class HotelSchemas
{
    public class SHotelMinimal
    {
        [MaxLength(255, ErrorMessage = "Name cannot be longer than 255 characters.")]
        public required string Name { get; set; }

        [MaxLength(255, ErrorMessage = "Location cannot be longer than 255 characters.")]
        public required string Location { get; set; }

        [Range(0, 5, ErrorMessage = "Rating must be between 0 and 5.")]
        [DefaultValue(0)]
        public decimal? Rating { get; set; } = 0;
    }

    public class SHotelExtended : SHotelMinimal
    {
        public long Id { get; set; }
        public List<SRoom> Rooms { get; set; } = [];
    }

    public class SRoom
    {
        public required long Id { get; set; }
        public required string RoomNumber { get; set; }
        public required long PricePerDay { get; set; }
        public required bool IsAvailable { get; set; }
    }


    public static IQueryable<SHotelExtended> ToHotelExtended(this IQueryable<Hotel> query)
    {
        return query.Select(h => new SHotelExtended
        {
            Id = h.Id,
            Name = h.Name,
            Location = h.Location,
            Rating = h.Rating,
            Rooms = h.Rooms.Select(r => new SRoom
            {
                Id = r.Id,
                RoomNumber = r.RoomNumber,
                PricePerDay = r.PricePerDay,
                IsAvailable = r.IsAvailable
            }).ToList()
        });
    }
}
