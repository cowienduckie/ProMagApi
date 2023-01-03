using API.Attributes;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/users")]
[Authorize]
[ApiController]
public class UsersController : BaseController
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }
}