using System.Collections.Generic;
using System.Threading.Tasks;
using MyAPI.Application.DTO.Request;
using MyAPI.Application.DTO.Response;
using MyAPI.Domain.Entities;

namespace MyAPI.Application.Abstraction;

 public interface IProductService
{
    public Task<IEnumerable<ProductItems>> GetAllProducts();

    public Task<Result<ProductReponseDTO>> AddProduct(ProductRequestDTO productRequest);

    public Task<Result<ProductReponseDTO>> UpdateProduct(ProductRequestDTO productRequest);
    
    public Task<Result<object>> DeleteProduct(int productId);
}
