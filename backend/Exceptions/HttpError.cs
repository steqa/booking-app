namespace backend.Exceptions;

public abstract class HttpError : Exception
{
    public HttpStatusCodeEnum StatusCode { get; }
    public string Error { get; }
    public override string Message { get; }
    public object? Details { get; }
    
    protected HttpError(
        HttpStatusCodeEnum statusCode,
        string error,
        string message,
        object details
    )
    {
        StatusCode = statusCode;
        Error = error;
        Message = message;
        Details = details;
    }
    
    protected HttpError(
        HttpStatusCodeEnum statusCode,
        string error,
        string message
    )
    {
        StatusCode = statusCode;
        Error = error;
        Message = message;
        Details = null;
    }
}