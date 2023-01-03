using Application.Common.Models;
using AutoMapper;
using Domain.Entities.Users;
using Infrastructure.Persistence.Interfaces;

namespace Application.Services.Implementations;

public class UserService : ServiceBase, IUserService
{
    public UserService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    }

    public async Task<UserInternalModel?> GetInternalModelByIdAsync(Guid id)
    {
        var userRepository = UnitOfWork.AsyncRepository<User>();

        var user = await userRepository.GetAsync(u => !u.IsDeleted && u.Id == id);

        if (user == null)
        {
            return null;
        }

        return Mapper.Map<UserInternalModel>(user);
    }
}