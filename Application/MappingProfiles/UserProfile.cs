using Application.Common.Models;
using AutoMapper;
using Domain.Entities.Users;

namespace Application.MappingProfiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, UserInternalModel>();
    }
}