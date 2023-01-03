using API.Attributes;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/projects")]
[Authorize]
[ApiController]
public class ProjectsController : BaseController
{
    private readonly IProjectService _projectService;

    public ProjectsController(IProjectService projectService)
    {
        _projectService = projectService;
    }
}