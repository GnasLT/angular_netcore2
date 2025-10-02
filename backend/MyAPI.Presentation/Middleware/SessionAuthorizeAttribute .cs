using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MyAPI.Application.DTO.Response;


public class SessionAuthorizeAttribute : Attribute, IAuthorizationFilter
{
    private readonly string? _role;

    public SessionAuthorizeAttribute(string? role = null)
    {
        _role = role;
    }

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var user = context.HttpContext.Items["Users"] as LoginResponse;
        if (user == null)
        {
            context.Result = new UnauthorizedResult();
            return;
        }

       if (!string.IsNullOrEmpty(_role) &&
            !string.Equals(user.Role, _role, StringComparison.OrdinalIgnoreCase))
        {
            context.Result = new ForbidResult();
        }
    }
}