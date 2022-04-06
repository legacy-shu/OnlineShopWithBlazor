using Microsoft.AspNetCore.Mvc;
using OnlineShop.API.Extenstions;
using OnlineShop.API.Repositories;
using ShopOnline.Models.Dtos;

namespace OnlineShop.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : Controller
{
    private readonly IProductRepository _productRepository;

    public ProductController(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductDto>>> GetItems()
    {
        try
        {
            var products = await _productRepository.GetItems();
            var productCategories = await _productRepository.GetCategories();
            if (products == null || productCategories == null)
            {
                return NotFound();
            }
            else
            {
                var productDtos = products.ConvertToDto(productCategories);
                return Ok(productDtos);
            }
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
        }
    }
}