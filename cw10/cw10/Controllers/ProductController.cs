using cw10.Exceptions;
using cw10.RequestModels;
using cw10.Services;
using cw10.Validators;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace cw10.Controllers;

[ApiController]
[Route("api/products")]
public class ProductController(IProductService service) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> AddNewProductWithCategories(ProductRequestModel request,
        IValidator<ProductRequestModel> validator)
    {
        var validate = await validator.ValidateAsync(request);
        if (!validate.IsValid)
        {
            return BadRequest(validate.ToDictionary());
        }

        try
        {
            await service.AddProduct(request);
            return  NoContent();
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (BadRequestException e)
        {
            return BadRequest(e.Message);
        }
    }
}