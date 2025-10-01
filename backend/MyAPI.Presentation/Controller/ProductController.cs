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
public class ProductController : ControllerBase
{
    private readonly IProductService _productservice;

    public ProductController(IProductService productservice)
    {
        _productservice = productservice;
    }


    [SessionAuthorize("seller")]
    [HttpGet("getall")]
    public async Task<IEnumerable<ProductItems>> GetAllProduct()
    {
        return await _productservice.GetAllProducts();
    }


    [SessionAuthorize("seller")]
    [HttpPost("add")]
    public async Task<Result<ProductReponseDTO>> AddProduct([FromBody] ProductRequestDTO request)
    {

        var result = await _productservice.AddProduct(request);
        if (!result.Success)
            return await Result<ProductReponseDTO>.FailureResult(result.Message);

        return await Result<ProductReponseDTO>.SuccessResult(result.Data, result.Message);

    }

    [SessionAuthorize("seller")]
    [HttpPut("update")]
    public async Task<Result<ProductReponseDTO>> UpdateProduct([FromBody] ProductRequestDTO request)
    {
        var result = await _productservice.UpdateProduct(request);
        if (!result.Success)
            return await Result<ProductReponseDTO>.FailureResult(result.Message);

        return await Result<ProductReponseDTO>.SuccessResult(result.Data, result.Message);
    }

    [SessionAuthorize("seller")]
    [HttpDelete("delete/{id}")]
    public async Task<Result<object>> DeleteProduct(int id)
    {
        
        var result = await _productservice.DeleteProduct(id);
        if (!result.Success)
            return await Result<object>.FailureResult(result.Message);
    
        return await Result<object>.FailureResult(result.Message);
        
    }
}