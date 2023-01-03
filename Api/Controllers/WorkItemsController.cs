using API.Attributes;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/items")]
[Authorize]
[ApiController]
public class WorkItemsController : BaseController
{
    private readonly IWorkItemService _workItemService;

    public WorkItemsController(IWorkItemService workItemService)
    {
        _workItemService = workItemService;
    }
}