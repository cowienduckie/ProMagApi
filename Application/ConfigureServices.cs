using Application.Services;
using Application.Services.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class ConfigureServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IProjectService, ProjectService>();
        services.AddScoped<IWorkColumnService, WorkColumnService>();
        services.AddScoped<IWorkItemService, WorkItemService>();

        return services;
    }
}