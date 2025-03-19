namespace bd.Exceptions;

public abstract class HttpError : Exception
{
    public HttpStatusCodeEnum StatusCode { get; }
    public override string Message { get; }

    protected HttpError(HttpStatusCodeEnum statusCode, string message) : base(message)
    {
        StatusCode = statusCode;
        Message = message;
    }
}
