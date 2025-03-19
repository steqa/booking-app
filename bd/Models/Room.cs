using System;
using System.Collections.Generic;

namespace bd.Models;

public partial class Room
{
    public long Id { get; set; }

    public long HotelId { get; set; }

    public string RoomNumber { get; set; } = null!;

    public long PricePerDay { get; set; }

    public bool IsAvailable { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual Hotel Hotel { get; set; } = null!;
}
