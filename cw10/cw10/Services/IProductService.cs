using cw10.RequestModels;

namespace cw10.Services;

public interface IProductService
{
    Task AddProduct(ProductRequestModel request);
}