namespace bd.Exceptions.Hotel;

public class EHotelNotFound()
    : HttpError(HttpStatusCodeEnum.NotFound, "Not Found", "Hotel not found.");
