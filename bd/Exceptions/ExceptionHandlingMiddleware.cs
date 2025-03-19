using System.Dynamic;
using System.Text.Json;

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

            var errorResponse = new ExpandoObject() as IDictionary<string, object>;
            errorResponse["code"] = httpError.StatusCode;
            errorResponse["error"] = httpError.Error;
            errorResponse["message"] = httpError.Message;
            if (httpError.Details != null)
                errorResponse["details"] = httpError.Details;

            await context.Response.WriteAsJsonAsync(errorResponse);
        }
        catch (Exception ex)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCodeEnum.InternalServerError;
            
            var errorResponse = new ExpandoObject() as IDictionary<string, object>;
            errorResponse["code"] = HttpStatusCodeEnum.InternalServerError;
            errorResponse["error"] = "Internal Server Error";
            errorResponse["message"] = ex.Message;
            
            await context.Response.WriteAsJsonAsync(errorResponse);
        }
    }
}
