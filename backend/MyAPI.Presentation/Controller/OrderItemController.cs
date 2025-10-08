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
public class OrderItemController : ControllerBase
{
    private readonly IOrderItemService _orderItemService;
    public OrderItemController(IOrderItemService orderItemService)
    {
        _orderItemService = orderItemService;
    }

    [SessionAuthorize("seller")]
    [HttpPut("Update")]
    public async Task<Result<object>> Update([FromBody] OrderItemDTO order)
    {
        var result = await _orderItemService.UpdateItem(order);
        if (!result.Success)
            return await Result<object>.FailureResult(result.Message);
        return await Result<object>.SuccessResult(null, result.Message);
    }

    [SessionAuthorize("admin")]
    [HttpDelete("Delete/{productid}")]
    public async Task<Result<object>> Delete(int productid)
    {
        var result = await _orderItemService.DeleteItem(productid);
        if (!result.Success)
            return await Result<object>.FailureResult(result.Message);
        return await Result<object>.SuccessResult(null, result.Message);
    }
    
    // [SessionAuthorize("seller")]
    // [HttpGet("getall")]
    // public async Task<IEnumerable<Orders>> GetAllOrder()
    // {
    //     return await _orderItemService.GetAllOrder();
    // }
}
