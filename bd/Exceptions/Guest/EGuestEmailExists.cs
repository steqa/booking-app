namespace bd.Exceptions.Guest;

public class EGuestEmailExists() : HttpError(HttpStatusCodeEnum.Conflict, "Guest with this email already exists.");