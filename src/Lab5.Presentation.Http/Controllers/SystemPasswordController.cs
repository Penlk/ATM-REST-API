using Lab5.Application.Contracts.SystemPasswords;
using Lab5.Application.Contracts.SystemPasswords.Operations;
using Lab5.Presentation.Http.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Lab5.Presentation.Http.Controllers;

[ApiController]
[Route("system-password")]
public class SystemPasswordController : ControllerBase
{
    private readonly ISystemPasswordService _systemPasswordService;

    public SystemPasswordController(ISystemPasswordService systemPasswordService)
    {
        _systemPasswordService = systemPasswordService;
    }

    [HttpPost("add")]
    public IActionResult CreateAdminPassword(CreateSystemPasswordRequest createSystemPasswordRequest)
    {
        var request = new CreateSystemPassword.Request(
            createSystemPasswordRequest.AdminSessionKey,
            createSystemPasswordRequest.Password);

        return _systemPasswordService.CreateSystemPassword(request) switch
        {
            CreateSystemPassword.Response.Failure failure => BadRequest(failure.Message),
            CreateSystemPassword.Response.Successfully successfully => Ok(),
            _ => throw new UnreachableException(),
        };
    }
}