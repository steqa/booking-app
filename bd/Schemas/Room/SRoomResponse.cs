using System.Diagnostics.CodeAnalysis;

namespace bd.Schemas.Room;

public class SRoomResponse
{
    public required long Id { get; set; }
    public required long HotelId { get; set; }
    public required string RoomNumber { get; set; }
    public required long PricePerDay { get; set; }
    public required bool IsAvailable { get; set; }

    [SetsRequiredMembers]
    public SRoomResponse(Models.Room room)
    {
        Id = room.Id;
        HotelId = room.HotelId;
        RoomNumber = room.RoomNumber;
        PricePerDay = room.PricePerDay;
        IsAvailable = room.IsAvailable;
    }
}