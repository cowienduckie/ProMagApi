using Infrastructure.Persistence.Interfaces;

namespace Application.Services.Implementations;

public class ServiceBase
{
    protected ServiceBase(IUnitOfWork unitOfWork)
    {
        UnitOfWork = unitOfWork;
    }

    protected internal IUnitOfWork UnitOfWork { get; }
}