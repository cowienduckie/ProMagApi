using API.Attributes;
using Application.Common.Models;
using Application.Dtos.Projects;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/projects")]
[ApiController]
public class ProjectsController : BaseController
{
    private readonly IProjectService _projectService;

    public ProjectsController(IProjectService projectService)
    {
        _projectService = projectService;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Wrapper<GetProjectResponse>>> GetAsync(Guid id)
    {
        var request = new GetProjectRequest(id);
        var response = await _projectService.GetAsync(request);

        return Ok(response);
    }
}