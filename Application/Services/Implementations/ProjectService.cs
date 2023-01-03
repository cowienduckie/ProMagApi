using Infrastructure.Persistence.Interfaces;

namespace Application.Services.Implementations;

public class ProjectService : ServiceBase, IProjectService
{
    public ProjectService(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }
}