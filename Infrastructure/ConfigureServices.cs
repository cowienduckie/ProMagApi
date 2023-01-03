﻿using Domain.Entities.Projects;
using Domain.Entities.Users;
using Domain.Entities.WorkColumns;
using Domain.Entities.WorkItems;
using Domain.Interfaces;
using Domain.Shared.Constants;
using Infrastructure.Common.Interfaces;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Interceptors;
using Infrastructure.Persistence.Interfaces;
using Infrastructure.Persistence.Repositories;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddScoped<AuditableEntitySaveChangesInterceptor>();

        services.AddDbContext<EfContext>(
            options => options.UseSqlServer(
                configuration.GetConnectionString(Settings.DbConnectionStringName),
                builder => builder.MigrationsAssembly(typeof(EfContext).Assembly.FullName)));

        services.AddScoped<IEfContext>(provider => provider.GetRequiredService<EfContext>());

        services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>))
            .AddScoped<IUserRepository, UserRepository>()
            .AddScoped<IWorkItemRepository, WorkItemRepository>()
            .AddScoped<IProjectRepository, ProjectRepository>()
            .AddScoped<IWorkColumnRepository, WorkColumnRepository>();

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<EfContextInitializer>();

        services.AddTransient<IDateTime, DateTimeService>();

        return services;
    }
}