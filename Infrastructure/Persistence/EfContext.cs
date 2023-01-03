using System.Reflection;
using Domain.Entities.Projects;
using Domain.Entities.Users;
using Domain.Entities.WorkColumns;
using Domain.Entities.WorkItems;
using Infrastructure.Persistence.Interceptors;
using Infrastructure.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class EfContext : DbContext, IEfContext
{
    private readonly AuditableEntitySaveChangesInterceptor _auditableEntitySaveChangesInterceptor;

    public EfContext(
        DbContextOptions<EfContext> options,
        AuditableEntitySaveChangesInterceptor auditableEntitySaveChangesInterceptor)
        : base(options)
    {
        _auditableEntitySaveChangesInterceptor = auditableEntitySaveChangesInterceptor;
    }

    public virtual DbSet<User> Users => Set<User>();
    public virtual DbSet<Project> Projects => Set<Project>();
    public virtual DbSet<WorkColumn> WorkColumns => Set<WorkColumn>();
    public virtual DbSet<WorkItem> WorkItems => Set<WorkItem>();

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(_auditableEntitySaveChangesInterceptor);
    }
}