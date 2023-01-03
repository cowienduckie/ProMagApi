using Domain.Interfaces;

namespace Domain.Entities.WorkItems;

public interface IWorkItemRepository : IAsyncRepository<WorkItem>
{
}