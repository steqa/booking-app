namespace backend.Exceptions.Hotel;

public class EHttpHotelNotFound()
    : HttpError(HttpStatusCodeEnum.NotFound, "Not Found", "Hotel not found");
