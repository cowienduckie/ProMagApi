using Infrastructure.Persistence.Interfaces;

namespace Application.Services.Implementations;

public class WorkItemService : ServiceBase, IWorkItemService
{
    public WorkItemService(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }
}