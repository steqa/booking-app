using bd.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

public static class RoomSchemas
{
    public class SRoomMinimal
    {
        [Range(1, long.MaxValue, ErrorMessage = "Hotel Id must be greater than or equal to 1.")]
        [DefaultValue(1)]
        public required long HotelId { get; set; }

        [MaxLength(10, ErrorMessage = "Room number cannot be longer than 10 characters.")]
        public required string RoomNumber { get; set; }

        [Range(0, long.MaxValue, ErrorMessage = "Price per day must be greater than or equal to 0.")]
        public required long PricePerDay { get; set; }

        [DefaultValue(true)]
        public bool? IsAvailable { get; set; } = true;
    }

    public class SRoomExtended : SRoomMinimal
    {
        public long Id { get; set; }
        public List<SBooking> Bookings { get; set; } = [];
    }

    public class SBooking
    {
        public required long Id { get; set; }
        public required long GuestId { get; set; }
        public required long RoomId { get; set; }
        public required DateTime CheckIn { get; set; }
        public required DateTime CheckOut { get; set; }
    }


    public static IQueryable<SRoomExtended> ToRoomExtended(this IQueryable<Room> query)
    {
        return query.Select(r => new SRoomExtended
        {
            Id = r.Id,
            HotelId = r.HotelId,
            RoomNumber = r.RoomNumber,
            PricePerDay = r.PricePerDay,
            IsAvailable = r.IsAvailable,
            Bookings = r.Bookings.Select(b => new SBooking
            {
                Id = b.Id,
                GuestId = b.GuestId,
                RoomId = b.RoomId,
                CheckIn = b.CheckIn,
                CheckOut = b.CheckOut,
            }).ToList()
        });
    }
}
