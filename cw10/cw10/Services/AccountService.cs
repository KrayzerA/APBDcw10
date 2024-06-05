using cw10.Exceptions;
using cw10.Models;
using cw10.ResponseModels;
using Microsoft.EntityFrameworkCore;

namespace cw10.Services;

public class AccountService(Cw10Context context) : IAccountService
{
    public async Task<AccountDetailsByIdResponseModel> GetAccountDetailsByIdAsync(int id)
    {
        var account = await context.Accounts.FirstOrDefaultAsync(a => a.IdAccount == id);
        if (account is null)
        {
            throw new NotFoundException($"Nie istnieje konta z id {id}");
        }

        return new AccountDetailsByIdResponseModel
        {
            FirstName = account.FirstName,
            LastName = account.LastName,
            Email = account.Email,
            Phone = account.Phone,
            Role = context.Roles.FirstOrDefault(r => r.IdRole == account.IdRole)!.Name,
            Cart = await context.ShoppingCarts.Where(sc => sc.IdAccount == account.IdAccount)
                .Select(sc => new ProductDetails
                {
                    ProductId = sc.IdProduct,
                    ProductName = sc.Product.Name,
                    Amount = sc.Amount
                }).ToListAsync()
        };
    }
}