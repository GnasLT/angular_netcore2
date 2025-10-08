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
public class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;
    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [SessionAuthorize("customer")]
    [HttpPost("Create")]
    public async Task<Result<object>> Create([FromBody] OrderRequestDTO orderdto)
    {
        var user = HttpContext.Items["Users"] as LoginResponse;
        if (user == null) return await Result<object>.FailureResult("Unauthorized");
        var result = await _orderService.CreateOrder(orderdto, user.SessionId);
        if (!result.Success)
            return await Result<object>.FailureResult(result.Message);
        return await Result<object>.SuccessResult(null, result.Message);
    }

    [SessionAuthorize("seller")]
    [HttpPut("Update")]
    public async Task<Result<object>> Update([FromBody] OrderIDRequest order)
    {
        var result = await _orderService.UpdateOrder(order);
        if (!result.Success)
            return await Result<object>.FailureResult(result.Message);
        return await Result<object>.SuccessResult(null, result.Message);
    }

    [SessionAuthorize("admin")]
    [HttpDelete("Delete/{id}")]
    public async Task<Result<object>> Delete(int id)
    {
        var result = await _orderService.DeleteOrder(id);
        if (!result.Success)
            return await Result<object>.FailureResult(result.Message);
        return await Result<object>.SuccessResult(null, result.Message);
    }
    
    [SessionAuthorize("seller")]
    [HttpGet("getall")]
    public async Task<IEnumerable<Orders>> GetAllOrder()
    {
        return await _orderService.GetAllOrder();
    }
}