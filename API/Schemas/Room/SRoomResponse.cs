using System.Diagnostics.CodeAnalysis;

namespace backend.Schemas.Room;

public class SRoomResponse
{
    public required long Id { get; set; }
    public required long HotelId { get; set; }
    public required string Number { get; set; }
    public required long PricePerDay { get; set; }
    public required bool IsAvailable { get; set; }

    [SetsRequiredMembers]
    public SRoomResponse(Models.Room room)
    {
        Id = room.Id;
        HotelId = room.HotelId;
        Number = room.Number;
        PricePerDay = room.PricePerDay;
        IsAvailable = room.IsAvailable;
    }
}