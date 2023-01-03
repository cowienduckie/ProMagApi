using Infrastructure.Persistence.Interfaces;

namespace Application.Services.Implementations;

public class WorkColumnService : ServiceBase, IWorkColumnService
{
    public WorkColumnService(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }
}