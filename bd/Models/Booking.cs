using System;
using System.Collections.Generic;

namespace bd.Models;

public partial class Booking
{
    public long Id { get; set; }

    public long GuestId { get; set; }

    public long RoomId { get; set; }

    public DateTime CheckIn { get; set; }

    public DateTime CheckOut { get; set; }

    public virtual Guest Guest { get; set; } = null!;

    public virtual Room Room { get; set; } = null!;
}
