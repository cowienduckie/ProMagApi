using API.Attributes;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/columns")]
[Authorize]
[ApiController]
public class WorkColumnsController : BaseController
{
    private readonly IWorkColumnService _workColumnService;

    public WorkColumnsController(IWorkColumnService workColumnService)
    {
        _workColumnService = workColumnService;
    }
}