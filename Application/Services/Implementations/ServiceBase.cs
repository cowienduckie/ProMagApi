using AutoMapper;
using Infrastructure.Persistence.Interfaces;

namespace Application.Services.Implementations;

public class ServiceBase
{
    protected ServiceBase(IUnitOfWork unitOfWork, IMapper mapper)
    {
        UnitOfWork = unitOfWork;
        Mapper = mapper;
    }

    protected internal IUnitOfWork UnitOfWork { get; }
    protected internal IMapper Mapper { get; }
}