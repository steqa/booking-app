using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models;

[Table("bookings")]
public partial class Booking
{
    [Key]
    public long Id { get; set; }

    [Column("guest_id")]
    [Required]
    public long GuestId { get; set; }

    [Column("room_id")]
    [Required]
    public long RoomId { get; set; }

    [Column("check_in")]
    [Required]
    public DateTime CheckIn { get; set; }

    [Column("check_out")]
    [Required]
    public DateTime CheckOut { get; set; }

    public virtual Guest Guest { get; set; }

    public virtual Room Room { get; set; }
}
