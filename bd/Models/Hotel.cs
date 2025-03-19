using System;
using System.Collections.Generic;

namespace bd.Models;

public partial class Hotel
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public string Location { get; set; } = null!;

    public decimal Rating { get; set; }

    public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();
}
