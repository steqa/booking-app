namespace bd.Exceptions;

public class EHttpValidation(object details)
    : HttpError(HttpStatusCodeEnum.BadRequest, "Bad Request", "Validation Error.", details);
