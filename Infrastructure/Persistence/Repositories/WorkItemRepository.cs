using Domain.Entities.WorkItems;

namespace Infrastructure.Persistence.Repositories;

public class WorkItemRepository : RepositoryBase<WorkItem>, IWorkItemRepository
{
    public WorkItemRepository(EfContext dbContext) : base(dbContext)
    {
    }
}