namespace backend.Repositories.Guest;

public interface IGuestRepository
{
    Task<Models.Guest> CreateGuest(Models.Guest guest);
    Task<Models.Guest?> GetGuest(GuestFilter? filters = null);
    Task<Models.Guest[]> GetGuests();
    Task<Models.Guest> UpdateGuest(Models.Guest guest);
    Task DeleteGuest(long id);
}