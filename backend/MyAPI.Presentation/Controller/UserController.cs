using System.Security.Claims;
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
            Result<LoginResponse> result = await _authenService.LoginAsync(userRequest);

            if (!result.Success)
            {
                return await Result<LoginResponse>.FailureResult(result.Message);
            }
            return await Result<LoginResponse>.SuccessResult(result.Data, result.Message);
        }


    }
}


