using System.ComponentModel.DataAnnotations;

namespace bd.Schemas.Guest;

public class SGuestUpdate
{
    [MaxLength(100, ErrorMessage = "First name cannot be longer than 100 characters.")]
    public required string FirstName { get; set; }

    [MaxLength(100, ErrorMessage = "Last name cannot be longer than 100 characters.")]
    public required string LastName { get; set; }

    [MaxLength(100, ErrorMessage = "Email cannot be longer than 100 characters.")]
    public required string Email { get; set; }

    [MaxLength(15, ErrorMessage = "Phone cannot be longer than 15 characters.")]
    public required string Phone { get; set; }
}