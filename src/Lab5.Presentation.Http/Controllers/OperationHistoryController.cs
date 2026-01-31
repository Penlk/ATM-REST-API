using Lab5.Application.Contracts.OperationHistories;
using Lab5.Application.Contracts.OperationHistories.Models;
using Lab5.Application.Contracts.OperationHistories.Operations;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Lab5.Presentation.Http.Controllers;

[ApiController]
[Route("history")]
public class OperationHistoryController : ControllerBase
{
    private readonly IOperationHistoryService _service;

    public OperationHistoryController(IOperationHistoryService service)
    {
        _service = service;
    }

    [HttpGet("operations/{id}")]
    public ActionResult<OperationHistoryDetailsDto> GetHistory(Guid id)
    {
        var request = new GetOperationHistoryDetails.Request(id);

        return _service.GetOperationHistoryDetails(request) switch
        {
            GetOperationHistoryDetails.Response.Failure failure => BadRequest(failure.Message),
            GetOperationHistoryDetails.Response.Successfully successfully => Ok(successfully.Operations),
            _ => throw new UnreachableException(),
        };
    }
}