namespace backend.Exceptions.Room;

public class EHttpRoomNotFound()
    : HttpError(HttpStatusCodeEnum.NotFound, "Not Found", "Room not found.");