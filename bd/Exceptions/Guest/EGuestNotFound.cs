namespace bd.Exceptions.Guest;

public class EGuestNotFound() : HttpError(HttpStatusCodeEnum.NotFound, "Guest not found.");