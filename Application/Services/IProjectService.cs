using Application.Common.Models;
using Application.Dtos.Projects;

namespace Application.Services;

public interface IProjectService
{
    Task<Wrapper<GetProjectListResponse>> ListAsync(GetProjectListRequest request);
    Task<Wrapper<GetProjectResponse>> GetAsync(GetProjectRequest request);
}