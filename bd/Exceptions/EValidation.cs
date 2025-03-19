namespace bd.Exceptions;

public class EValidation(object details)
    : HttpError(HttpStatusCodeEnum.BadRequest, "Bad Request", "Validation Error.", details);
