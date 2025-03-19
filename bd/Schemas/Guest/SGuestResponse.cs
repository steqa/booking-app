using System.Diagnostics.CodeAnalysis;

namespace bd.Schemas.Guest;

public class SGuestResponse
{
    public required long Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public required string Phone { get; set; }

    [SetsRequiredMembers]
    public SGuestResponse(Models.Guest guest)
    {
        Id = guest.Id;
        FirstName = guest.FirstName;
        LastName = guest.LastName;
        Email = guest.Email;
        Phone = guest.Phone;
    }
}