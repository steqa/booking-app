using backend.Exceptions.Guest;
using backend.Repositories.Guest;
using backend.Schemas.Guest;

namespace backend.Services.Guest;

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
            throw new EHttpGuestEmailExists();
        
        guest = await _guestRepository.CreateGuest(new Models.Guest
        {
            FirstName = data.FirstName,
            LastName = data.LastName,
            Email = data.Email,
            Phone = data.Phone,
        });
        
        return new SGuestResponse(guest);
    }
    
    public async Task<SGuestResponse> GetGuest(long id)
    {
        var guest = await _guestRepository.GetGuest(new GuestFilter { Id = id });
        if (guest == null)
            throw new EHttpGuestNotFound();

        return new SGuestResponse(guest);
    }

    public async Task<SGuestResponse[]> GetGuests()
    {
        var guests = await _guestRepository.GetGuests();
        
        return guests.Select(guest => new SGuestResponse(guest)).ToArray();
    }

    public async Task<SGuestResponse> UpdateGuest(long id, SGuestUpdate data)
    {
        var guest = await _guestRepository.GetGuest(new GuestFilter { Id = id });
        if (guest == null)
            throw new EHttpGuestNotFound();

        if (guest.Email != data.Email)
        {
            var existingGuest = await _guestRepository.GetGuest(new GuestFilter { Email = data.Email });
            if (existingGuest != null) 
                throw new EHttpGuestEmailExists();
        }
        
        guest.FirstName = data.FirstName;
        guest.LastName = data.LastName;
        guest.Email = data.Email;
        guest.Phone = data.Phone;
        
        guest = await _guestRepository.UpdateGuest(guest);
        
        return new SGuestResponse(guest);
    }

    public async Task DeleteGuest(long id)
    {
        var guest = await _guestRepository.GetGuest(new GuestFilter { Id = id });
        if (guest == null)
            throw new EHttpGuestNotFound();
        
        await _guestRepository.DeleteGuest(id);
    }
}