using Lab5.Application.Contracts.Accounts;
using Lab5.Application.Contracts.Accounts.Models;
using Lab5.Application.Contracts.Accounts.Operations;
using Lab5.Presentation.Http.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Lab5.Presentation.Http.Controllers;

[ApiController]
[Route("api/account")]
public class AccountController : ControllerBase
{
    private readonly IAccountService _accountService;

    public AccountController(IAccountService accountService)
    {
        _accountService = accountService;
    }

    [HttpPost("account")]
    public ActionResult<AccountDto> CreateUserAccount(CreateAccountRequest createAccountRequest)
    {
        var request = new CreateAccount.Request(createAccountRequest.SessionId, createAccountRequest.PinCode);

        return _accountService.CreateAccount(request) switch
        {
            CreateAccount.Response.Failure failure => BadRequest(failure.Message),
            CreateAccount.Response.Successfully successfully => Ok(successfully.AccountDto),
            _ => throw new UnreachableException(),
        };
    }

    [HttpGet("account/{id}")]
    public ActionResult<int> GetUserAccountBalance(Guid id)
    {
        var request = new GetAccountBalance.Request(id);

        return _accountService.GetAccountBalance(request) switch
        {
            GetAccountBalance.Response.Failure failure => BadRequest(failure.Message),
            GetAccountBalance.Response.Successfully successfully => Ok(successfully.Balance),
            _ => throw new UnreachableException(),
        };
    }

    [HttpPost("account/replenish")]
    public ActionResult<int> ReplenishUserAccount(OperationWithMoneyRequest operationWithMoneyRequest)
    {
        var request =
            new ReplenishAccountBalance.Request(operationWithMoneyRequest.SessionId, operationWithMoneyRequest.Money);

        return _accountService.ReplenishAccountBalance(request) switch
        {
            ReplenishAccountBalance.Response.Failure failure => BadRequest(failure.Message),
            ReplenishAccountBalance.Response.Successfully successfully => Ok(successfully.Balance),
            _ => throw new UnreachableException(),
        };
    }

    [HttpPost("account/with-draw")]
    public ActionResult<int> WithDrawUserAccount(OperationWithMoneyRequest operationWithMoneyRequest)
    {
        var request =
            new WithDrawAccountBalance.Request(operationWithMoneyRequest.SessionId, operationWithMoneyRequest.Money);

        return _accountService.WithDrawAccountBalance(request) switch
        {
            WithDrawAccountBalance.Response.Failure failure => BadRequest(failure.Message),
            WithDrawAccountBalance.Response.Successfully successfully => Ok(successfully.Balance),
            _ => throw new UnreachableException(),
        };
    }
}