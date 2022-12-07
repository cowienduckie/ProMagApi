using API.Attributes;
using API.Controllers;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/accounts")]
[Authorize]
public class AccountsController : BaseController
{
    private readonly IUserService _userService;

    public AccountsController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet("/api/test")]
    [AllowAnonymous]
    public IActionResult Test()
    {
        return Ok("Test connection OK!");
    }
}