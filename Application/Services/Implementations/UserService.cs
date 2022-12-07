using Application.Common.Models;
using Domain.Entities.Users;
using Infrastructure.Persistence.Interfaces;

namespace Application.Services.Implementations;

public class UserService : ServiceBase, IUserService
{
    public UserService(IUnitOfWork unitOfWork) : base(unitOfWork)
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

        return new UserInternalModel(user);
    }
}