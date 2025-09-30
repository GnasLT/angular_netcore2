using System.Threading.Tasks;
using MyAPI.Application.Abstraction;
using MyAPI.Application.DTO.Request;
using MyAPI.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using MyAPI.Application.DTO.Response;

namespace MyAPI.Presentation.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IAuthenService _authenService;

        public UserController(IAuthenService authenService)
        {

            this._authenService = authenService;
        }

        [HttpPost("/login")]
        public async Task<Result<LoginResponse>> Login([FromBody] LoginRequest userRequest)
        {
            var ipAddress = HttpContext.Connection.RemoteIpAddress.ToString();
            var userAgent = Request.Headers["User-Agent"].ToString();
            Result<LoginResponse> result = await _authenService.LoginAsync(userRequest, ipAddress,userAgent);
            if (!result.Success)
            {
                return await Result<LoginResponse>.FailureResult(result.Message);
            }
            Response.Cookies.Append(
                "MySession",
                result.Data!.SessionId.ToString(),
                new CookieOptions { HttpOnly = true, Secure = true, SameSite = SameSiteMode.Lax }
            );
            return await Result<LoginResponse>.SuccessResult(null, result.Message);
        }


    }
}


