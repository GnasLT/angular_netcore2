using MyAPI.Application.Abstraction;

namespace MyAPI.Presentation.Middleware;

public class SessionMiddleware
{
    private readonly RequestDelegate _next;

    public SessionMiddleware(RequestDelegate next) => _next = next;

    public async Task InvokeAsync(HttpContext context, IAuthenService authenService)
    {
        if (context.Request.Cookies.TryGetValue("MySession", out var sessionIdString)
         && Guid.TryParse(sessionIdString, out var sessionId))
        {
            var ip = context.Connection.RemoteIpAddress.ToString();
            var useragent = context.Request.Headers["User-Agent"].ToString();
            var user = await authenService.ValidateSessionAsync(sessionId, ip, useragent);
            if (user != null)
            {
                context.Items["Users"] = user;
            }
            else
            {   
                context.Response.Cookies.Delete("MySession");
            }
        }


        await _next(context);
    }
    
}