using bd.Exceptions.Guest;
using bd.Models;
using bd.Repositories.Guest;
using bd.Schemas.Guest;

namespace bd.Services;

public class GuestService : IGuestService
{
    private readonly IGuestRepository _guestRepository;

    public GuestService(IGuestRepository guestRepository)
    {
        _guestRepository = guestRepository;
    }

    public async Task<SGuestResponse> CreateGuest(SGuestCreate data)
    {
        var guest = await _guestRepository.GetGuest(new GuestFilter { Email = data.Email });
        if (guest != null) 
            throw new EGuestEmailExists();
        
        guest = await _guestRepository.CreateGuest(new Guest
        {
            FirstName = data.FirstName,
            LastName = data.LastName,
            Email = data.Email,
            Phone = data.Phone,
        });
        
        return new SGuestResponse(guest);
    }
    
    public async Task<SGuestResponse?> GetGuest(long id)
    {
        var guest = await _guestRepository.GetGuest(new GuestFilter { Id = id });
        if (guest == null)
            throw new EGuestNotFound();

        return new SGuestResponse(guest);
    }

    public async Task<SGuestResponse[]> GetGuests()
    {
        var guests = await _guestRepository.GetGuests();
        
        return guests.Select(guest => new SGuestResponse(guest)).ToArray();
    }

    public async Task<SGuestResponse?> UpdateGuest(long id, SGuestUpdate data)
    {
        var guest = await _guestRepository.GetGuest(new GuestFilter { Id = id });
        if (guest == null)
            throw new EGuestNotFound();
        
        guest = await _guestRepository.GetGuest(new GuestFilter { Email = data.Email });
        if (guest != null) 
            throw new EGuestEmailExists();
        
        guest = await _guestRepository.UpdateGuest(new Guest
        {
            Id = id,
            FirstName = data.FirstName,
            LastName = data.LastName,
            Email = data.Email,
            Phone = data.Phone,
        });
        
        return new SGuestResponse(guest);
    }

    public async Task DeleteGuest(long id)
    {
        var guest = await _guestRepository.GetGuest(new GuestFilter { Id = id });
        if (guest == null)
            throw new EGuestNotFound();
        
        await _guestRepository.DeleteGuest(id);
    }
}