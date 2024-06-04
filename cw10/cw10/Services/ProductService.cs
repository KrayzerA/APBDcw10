using cw10.Exceptions;
using cw10.Models;
using cw10.RequestModels;
using Microsoft.EntityFrameworkCore;

namespace cw10.Services;

public class ProductService(Cw10Context context) : IProductService
{
    public async Task AddProduct(ProductRequestModel request)
    {
        var checkProduct = await context.Products.Where(p => p.Name.Equals(request.ProductName)).FirstOrDefaultAsync();
        if (checkProduct is not null)
        {
            throw new BadRequestException($"Product with name {checkProduct.Name} already exists");
        }

        var categories = await context.Categories.Where(c => request.ProductCategories.Contains(c.IdCategory))
            .ToListAsync();
        if (categories.Count != request.ProductCategories.Count)
        {
            var idCategorisList = categories.Select(c => c.IdCategory).ToList();
            foreach (var idCategory in request.ProductCategories)
            {
                if (!idCategorisList.Contains(idCategory))
                {
                    throw new BadRequestException($"Category with id {idCategory} does not exists");
                }
            }
        }
        
        var productToAdd = new Product
        {
            Name = request.ProductName,
            Weight = request.ProductWeight,
            Height = request.ProductHeight,
            Width = request.ProductWidth,
            Depth = request.ProductDepth,
            Categories = categories
        };
        await context.Products.AddAsync(productToAdd);
        foreach (var category in categories)
        {
            category.Products.Add(productToAdd);
        }

        await context.SaveChangesAsync();
    }
}