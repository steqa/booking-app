using System.Diagnostics.CodeAnalysis;

namespace backend.Schemas.Room;

public class SRoomBookingsResponse
{
    public required long Id { get; set; }
    public required long HotelId { get; set; }
    public required string Number { get; set; }
    public required long PricePerDay { get; set; }
    public required bool IsAvailable { get; set; }
    public List<SRoomBookingsResponseBooking> Bookings { get; set; }

    public class SRoomBookingsResponseBooking
    {
        public required long Id { get; set; }
        public required long GuestId { get; set; }
        public required DateTime CheckIn { get; set; }
        public required DateTime CheckOut { get; set; }
    }
    
    [SetsRequiredMembers]
    public SRoomBookingsResponse(Models.Room room)
    {
        Id = room.Id;
        HotelId = room.HotelId;
        Number = room.Number;
        PricePerDay = room.PricePerDay;
        IsAvailable = room.IsAvailable;
        Bookings = room.Bookings.Select(b => new SRoomBookingsResponseBooking
        {
            Id = b.Id,
            GuestId = b.GuestId,
            CheckIn = b.CheckIn,
            CheckOut = b.CheckOut,
        }).ToList();
    }
}