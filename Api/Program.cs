using API.Extensions;
using API.Hubs;
using API.Middlewares;
using Application;
using Infrastructure;
using Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructureServices(builder.Configuration);

builder.Services.AddApplicationServices();

builder.Services.AddWebUiServices();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

var app = builder.Build();

var logger = app.Services.GetRequiredService<ILogger>();

app.ConfigureExceptionHandler(logger);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
{
    var initializer = scope.ServiceProvider.GetRequiredService<EfContextInitializer>();

    await initializer.InitializeAsync();
    await initializer.SeedAsync();
}

app.UseHealthChecks("/health");

app.UseRouting();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.UseCors("CorsPolicy");

app.MapHub<ProjectHub>("/project-hub");

app.UseMiddleware<JwtMiddleware>();

app.MapControllers();

app.Run();