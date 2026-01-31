using Lab5.Application.Contracts.Sessions;
using Lab5.Application.Contracts.Sessions.Models;
using Lab5.Application.Contracts.Sessions.Operations;
using Lab5.Presentation.Http.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Lab5.Presentation.Http.Controllers;

[ApiController]
[Route("sessions")]
public class SessionController : ControllerBase
{
    private readonly ISessionService _service;

    public SessionController(ISessionService service)
    {
        _service = service;
    }

    [HttpPost("user")]
    public ActionResult<UserSessionDto> CreateUserSessionSingle(CreateUserSessionRequest createUserSessionRequest)
    {
        var request = new CreateUserSession.Request(createUserSessionRequest.Id, createUserSessionRequest.PinCode);

        return _service.CreateUserSession(request) switch
        {
            CreateUserSession.Response.Failure failure => BadRequest(failure.Message),
            CreateUserSession.Response.Successfully successfully => Ok(successfully.UserSessionDto),
            _ => throw new UnreachableException(),
        };
    }

    [HttpPost("admin")]
    public ActionResult<AdminSessionDto> CreateAdminSessionSingle(CreateAdminSessionRequest createAdminSessionRequest)
    {
        var request = new CreateAdminSession.Request(createAdminSessionRequest.Password);

        return _service.CreateAdminSession(request) switch
        {
            CreateAdminSession.Response.Failure failure => BadRequest(failure.Message),
            CreateAdminSession.Response.Successfully successfully => Ok(successfully.AdminSessionDto),
            _ => throw new UnreachableException(),
        };
    }
}