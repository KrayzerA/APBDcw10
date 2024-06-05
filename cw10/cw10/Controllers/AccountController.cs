using cw10.Exceptions;
using cw10.Services;
using Microsoft.AspNetCore.Mvc;

namespace cw10.Controllers;

[ApiController]
[Route("api/accounts")]
public class AccountController(IAccountService service) : ControllerBase
{

    [HttpGet("{idAccount:int}")]
    public async Task<IActionResult> GetAccountDetailsById(int idAccount)
    {
        try
        {
            return Ok(await service.GetAccountDetailsByIdAsync(idAccount));
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
}