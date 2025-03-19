using bd.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

public static class BookingSchemas
{
    public class SBookingMinimal
    {
        [Range(1, long.MaxValue, ErrorMessage = "Guest Id must be greater than or equal to 1.")]
        [DefaultValue(1)]
        public required long GuestId { get; set; }

        [Range(1, long.MaxValue, ErrorMessage = "Room Id must be greater than or equal to 1.")]
        [DefaultValue(1)]
        public required long RoomId { get; set; }

        public required DateTime CheckIn { get; set; }

        public required DateTime CheckOut { get; set; }
    }
    public class SBookingExtended : SBookingMinimal
    {
        public required long Id { get; set; }
        public required SGuest Guest { get; set; }
        public required SRoom Room { get; set; }
    }

    public class SGuest
    {
        public required long Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string Phone { get; set; }
    }

    public class SRoom
    {
        public required long Id { get; set; }
        public required long HotelId { get; set; }
        public required string RoomNumber { get; set; }
        public required long PricePerDay { get; set; }
        public required bool IsAvailable { get; set; }
    }


    public static IQueryable<SBookingExtended> ToBookingExtended(this IQueryable<Booking> query)
    {
        return query.Select(b => new SBookingExtended
        {
            Id = b.Id,
            GuestId = b.GuestId,
            RoomId = b.RoomId,
            CheckIn = b.CheckIn,
            CheckOut = b.CheckOut,
            Guest = new SGuest
            {
                Id = b.Guest.Id,
                FirstName = b.Guest.FirstName,
                LastName = b.Guest.LastName,
                Email = b.Guest.Email,
                Phone = b.Guest.Phone,
            },
            Room = new SRoom
            {
                Id = b.Room.Id,
                HotelId = b.Room.HotelId,
                RoomNumber = b.Room.RoomNumber,
                PricePerDay = b.Room.PricePerDay,
                IsAvailable = b.Room.IsAvailable,
            },
        });
    }
}
