using cw10.ResponseModels;

namespace cw10.Services;

public interface IAccountService
{
    Task<AccountDetailsByIdResponseModel> GetAccountDetailsByIdAsync(int id);
}
