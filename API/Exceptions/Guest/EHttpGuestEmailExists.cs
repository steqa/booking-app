namespace backend.Exceptions.Guest;

public class EHttpGuestEmailExists()
    : HttpError(HttpStatusCodeEnum.Conflict, "Conflict", "Guest with this email already exists");