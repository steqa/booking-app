namespace bd.Exceptions.Booking;

public class EHttpBookingNotFound()
    : HttpError(HttpStatusCodeEnum.NotFound, "Not Found", "Booking not found.");