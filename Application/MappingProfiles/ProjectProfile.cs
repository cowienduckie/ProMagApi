using Application.Dtos.Projects;
using AutoMapper;
using Domain.Entities.Projects;

namespace Application.MappingProfiles;

public class ProjectProfile : Profile
{
    public ProjectProfile()
    {
        CreateMap<Project, GetProjectResponse>();
    }
}