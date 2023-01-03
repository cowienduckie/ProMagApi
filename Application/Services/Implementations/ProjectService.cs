using Application.Common.Models;
using Application.Dtos.Projects;
using AutoMapper;
using Domain.Entities.Projects;
using Domain.Shared.Constants;
using Infrastructure.Persistence.Interfaces;

namespace Application.Services.Implementations;

public class ProjectService : ServiceBase, IProjectService
{
    public ProjectService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    }

    public async Task<Wrapper<GetProjectResponse>> GetAsync(GetProjectRequest request)
    {
        var projectRepository = UnitOfWork.AsyncRepository<Project>();
        var project = await projectRepository.GetAsync(p => !p.IsDeleted && p.Id == request.Id);

        return new Wrapper<GetProjectResponse>(true, Messages.ActionSuccess, Mapper.Map<GetProjectResponse>(project));
    }

    public Task<Wrapper<GetProjectListResponse>> ListAsync(GetProjectListRequest request)
    {
        throw new NotImplementedException();
    }
}