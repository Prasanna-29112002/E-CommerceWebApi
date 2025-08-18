using log4net;
public class AuthorizationLoggingMiddleware
{
    private readonly RequestDelegate _next;
    private static readonly ILog log = LogHelper.Logger;

    public AuthorizationLoggingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        await _next(context);

        if (context.Response.StatusCode == StatusCodes.Status403Forbidden)
        {
            var user = context.User.Identity?.Name ?? "Unknown";
            log.Warn($"403 Forbidden - Unauthorized access attempt by user: {user}, Path: {context.Request.Path}");
        }
    }
}
