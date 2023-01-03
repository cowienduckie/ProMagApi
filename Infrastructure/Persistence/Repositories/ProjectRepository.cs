using Domain.Entities.Projects;

namespace Infrastructure.Persistence.Repositories;

public class ProjectRepository : RepositoryBase<Project>, IProjectRepository
{
    public ProjectRepository(EfContext dbContext) : base(dbContext)
    {
    }
}