using Application.Common.Models;
using Domain.Shared.Constants;
using Domain.Shared.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace API.Attributes;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class AuthorizeAttribute : Attribute, IAuthorizationFilter
{
    private readonly IList<UserRole> _roles;

    public AuthorizeAttribute(params UserRole[]? roles)
    {
        _roles = roles ?? Array.Empty<UserRole>();
    }

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var isAnonymousAllowed = context
            .ActionDescriptor
            .EndpointMetadata
            .OfType<AllowAnonymousAttribute>()
            .Any();

        if (isAnonymousAllowed)
        {
            return;
        }

        var user = context.HttpContext.Items[Settings.CurrentUserContextKey] as UserInternalModel;

        if (user == null || (_roles.Any() && !_roles.Contains(user.Role)))
        {
            context.Result = new UnauthorizedResult();
        }
    }
}