using bd.Schemas.Guest;

namespace bd.Services.Guest;

public interface IGuestService
{
    Task<SGuestResponse> CreateGuest(SGuestCreate data);
    Task<SGuestResponse?> GetGuest(long id);
    Task<SGuestResponse[]> GetGuests();
    Task<SGuestResponse?> UpdateGuest(long id, SGuestUpdate data);
    Task DeleteGuest(long id);
}