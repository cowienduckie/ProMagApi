using Domain.Entities.Projects;
using Domain.Entities.Users;
using Domain.Shared.Enums;
using Domain.Shared.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Persistence;

public class EfContextInitializer
{
    private readonly EfContext _context;
    private readonly ILogger<EfContextInitializer> _logger;

    public EfContextInitializer(
        ILogger<EfContextInitializer> logger,
        EfContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task InitializeAsync()
    {
        try
        {
            if (_context.Database.IsSqlServer())
            {
                await _context.Database.MigrateAsync();
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while initializing the database.");
            throw;
        }
    }

    public async Task SeedAsync()
    {
        try
        {
            await TrySeedAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while seeding the database.");
            throw;
        }
    }

    private async Task TrySeedAsync()
    {
        if (_context.Database.IsSqlServer())
        {
            if (!_context.Users.Any())
            {
                var user = new User
                {
                    Id = Guid.NewGuid(),
                    Username = "admin",
                    HashedPassword = StringHelper.HashString("admin@123"),
                    Role = UserRole.ProjectManager,
                    StaffCode = "PM0001",
                    FirstName = "Minh",
                    LastName = "Tran",
                    DateOfBirth = new DateTime(2000, 4, 24),
                    Gender = Gender.Male
                };

                _context.Users.Add(user);

                var project = new Project
                {
                    Id = Guid.NewGuid(),
                    Name = "ProMag",
                    Description = "A minimal project management system",
                };

                _context.Projects.Add(project);

                await _context.SaveChangesAsync();
            }
        }
    }
}