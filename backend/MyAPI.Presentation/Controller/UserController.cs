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

namespace MyAPI.Presentation.Controller;


[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IAdminService _adminservice;

    public UserController(IAdminService adminservice)
    {
        _adminservice = adminservice;
    }

    [SessionAuthorize("admin")]
    [HttpPost("changerole")]
    public async Task<Result<object>> ChangeRole([FromBody] UserRequest userRequest)
    {
        var result = await _adminservice.ChangeRole(userRequest);
        if (!result.Success)
            return await Result<object>.FailureResult(result.Message);
        return await Result<object>.SuccessResult(null, result.Message);
    } 
    
    [HttpPost("register")]
    public async Task<Result<object>> Register([FromBody] UserRegister userRegister)
    {
        var result = await _adminservice.Register(userRegister);
        if (!result.Success)
            return await Result<object>.FailureResult(result.Message);
        return await Result<object>.SuccessResult(null, result.Message);
    }
}