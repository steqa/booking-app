using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models;

[Table("guests")]
public partial class Guest
{
    [Key]
    public long Id { get; set; }

    [Column("first_name")]
    [Required]
    [MaxLength(100)]
    public string FirstName { get; set; }

    [Column("last_name")]
    [Required]
    [MaxLength(100)]
    public string LastName { get; set; }

    [Column("email")]
    [Required]
    [MaxLength(100)]
    public string Email { get; set; }

    [Column("phone")]
    [Required]
    [MaxLength(15)]
    public string Phone { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; }
}
