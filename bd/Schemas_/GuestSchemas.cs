using bd.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

public static class GuestSchemas
{
    public class SGuestMinimal
    {
        [MaxLength(100, ErrorMessage = "First name cannot be longer than 100 characters.")]
        public required string FirstName { get; set; } = null!;

        [MaxLength(100, ErrorMessage = "Last name cannot be longer than 100 characters.")]
        public required string LastName { get; set; } = null!;

        [MaxLength(100, ErrorMessage = "Email cannot be longer than 100 characters.")]
        public required string Email { get; set; } = null!;

        [MaxLength(15, ErrorMessage = "Phone cannot be longer than 15 characters.")]
        public required string Phone { get; set; } = null!;
    }

    public class SGuestExtended : SGuestMinimal
    {
        public required long Id { get; set; }
    }


    public static IQueryable<SGuestExtended> ToGuestExtended(this IQueryable<Guest> query)
    {
        return query.Select(g => new SGuestExtended
        {
            Id = g.Id,
            FirstName = g.FirstName,
            LastName = g.LastName,
            Email = g.Email,
            Phone = g.Phone,
        });
    }
}
