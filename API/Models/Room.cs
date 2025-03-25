using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models;

[Table("rooms")]
public partial class Room
{
    [Key]
    public long Id { get; set; }
    
    [Column("hotel_id")]
    [Required]
    public long HotelId { get; set; }
    
    [Column("number")]
    [Required]
    [MaxLength(10)]
    public string Number { get; set; } = null!;

    [Column("price_per_day")]
    [Required]
    [Range(0, long.MaxValue)]
    public long PricePerDay { get; set; }

    [Column("is_available")]
    [Required]
    [DefaultValue(true)]
    public bool IsAvailable { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual Hotel Hotel { get; set; } = null!;
}
