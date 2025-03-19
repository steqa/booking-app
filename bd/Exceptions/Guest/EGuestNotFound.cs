namespace bd.Exceptions.Guest;

public class EGuestNotFound()
    : HttpError(HttpStatusCodeEnum.NotFound, "Not Found", "Guest not found.");