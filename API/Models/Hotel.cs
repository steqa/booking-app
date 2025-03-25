using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models;

[Table("hotels")]
public partial class Hotel
{
    [Key]
    public long Id { get; set; }

    [Column("name")]
    [Required]
    [MaxLength(255)]
    public string Name { get; set; }

    [Column("location")]
    [Required]
    [MaxLength(255)]
    public string Location { get; set; }

    [Column("rating")]
    [Required]
    [Range(0.0, 5.0)]
    [DefaultValue(0.0)]
    public decimal Rating { get; set; }

    public virtual ICollection<Room> Rooms { get; set; }
}
