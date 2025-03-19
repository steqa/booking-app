namespace bd.Exceptions;

public class ExceptionHandlingMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (HttpError httpError)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)httpError.StatusCode;
            var errorResponse = new { message = httpError.Message, code = httpError.StatusCode };
            await context.Response.WriteAsJsonAsync(errorResponse);
        }
        catch (Exception ex)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCodeEnum.InternalServerError;
            var errorResponse = new { message = ex.Message, code = HttpStatusCodeEnum.InternalServerError };
            await context.Response.WriteAsJsonAsync(errorResponse);
        }
    }
}
