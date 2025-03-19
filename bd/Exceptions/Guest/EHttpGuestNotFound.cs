namespace bd.Exceptions.Guest;

public class EHttpGuestNotFound()
    : HttpError(HttpStatusCodeEnum.NotFound, "Not Found", "Guest not found.");