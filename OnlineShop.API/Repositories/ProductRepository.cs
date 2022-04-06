using Microsoft.EntityFrameworkCore;
using OnlineShop.API.Data;
using OnlineShop.API.Entities;

namespace OnlineShop.API.Repositories;

public class ProductRepository: IProductRepository
{
    private readonly ShopOnlineDbContext _shopOnlineDbContext;

    public ProductRepository(ShopOnlineDbContext context)
    {
        _shopOnlineDbContext = context;
    }
    public async Task<IEnumerable<Product>> GetItems()
    {
        var products = await _shopOnlineDbContext.Products.ToListAsync();
        return products;
    }

    public async Task<IEnumerable<ProductCategory>> GetCategories()
    {
        var categories = await _shopOnlineDbContext.ProductCategories.ToListAsync();
        return categories;
    }

    public Task<Product> GetItem(int id)
    {
        throw new NotImplementedException();
    }

    public Task<ProductCategory> GetCategory(int id)
    {
        throw new NotImplementedException();
    }
}