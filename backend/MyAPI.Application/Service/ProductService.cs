using MyAPI.Application.Abstraction;
using MyAPI.Application.DTO.Request;
using MyAPI.Application.DTO.Response;
using MyAPI.Domain.Entities;
using MyAPI.Domain.Repository;


namespace MyAPI.Application.Service;

public class ProductService : IProductService
{

    private readonly IProductRepository _productrepository;

    public ProductService(IProductRepository productrepository)
    {
        _productrepository = productrepository;
    }
    public async Task<IEnumerable<ProductItems>> GetAllProducts()
    {
        var products = await _productrepository.GetAllAsync();
        var dtoList = products.Select(p => new ProductItems
        {
            Name = p.Name,
            Price = p.Price,
            Stock = p.Stock,
            Categories = p.categoryid
        }).ToList();
        return dtoList;
    }

    public async Task<Result<ProductReponseDTO>> AddProduct(ProductRequestDTO productRequest)
    {
        ProductReponseDTO reponseDTO = new ProductReponseDTO();
        reponseDTO.OrderDate = productRequest.OrderDate;
        foreach (var item in productRequest.Items)
        {
            Products temp = await _productrepository.GetByIdAsync(item.Id);
            if (temp == null)
            {
                _productrepository.AddAsync(new Products(item.Id, item.Name, item.Price, item.Stock));
                reponseDTO.Items.Add(new ProductItemsResponseDTO
                {
                    Name = item.Name,
                    Price = item.Price,
                    Stock = item.Stock,
                    Categories = item.Categories
                });
            }
            else
            {
                return await Result<ProductReponseDTO>.FailureResult("Product ID already exists");
            }
        }
        return await Result<ProductReponseDTO>.SuccessResult(reponseDTO, "Add product successfully");
    }

    public async Task<Result<ProductReponseDTO>> UpdateProduct(ProductRequestDTO productRequest)
    {
        ProductReponseDTO reponseDTO = new ProductReponseDTO();
        reponseDTO.OrderDate = productRequest.OrderDate;
        foreach (var item in productRequest.Items)
        {
            Products temp = await _productrepository.GetByIdAsync(item.Id);
            if (temp != null)
            {
                temp.UpdateProduct(item.Name, item.Price, item.Stock);
                _productrepository.UpdateAsync(temp);
                reponseDTO.Items.Add(new ProductItemsResponseDTO
                {
                    Name = item.Name,
                    Price = item.Price,
                    Stock = item.Stock,
                    Categories = item.Categories
                });
            }
            else
            {
                return await Result<ProductReponseDTO>.FailureResult("Product ID does not exist");
            }
        }
        return await Result<ProductReponseDTO>.SuccessResult(reponseDTO, "Update product successfully");
    }

    public async Task<Result<object>> DeleteProduct(int productId)
    {
        Products temp = await _productrepository.GetByIdAsync(productId);
        if (temp != null)
        {
            await _productrepository.DeleteAsync(productId);
            return await Result<object>.SuccessResult(null, "Deleted the product");
        }
        else
        {
            return await Result<object>.FailureResult("Can't find the product");
        }
    }

    public async Task<Result<object>> IncreaseStock(ProductStock stock)
    {
        Products product = await _productrepository.GetByIdAsync(stock.Id);
        if (product != null)
        {
            product.IncreaseStock(stock.Stock);
            return await Result<object>.SuccessResult(null, "Stock is increased");
        } 
        return await Result<object>.FailureResult("Can't find the product");

    }

   
    
}