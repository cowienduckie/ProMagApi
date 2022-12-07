using Application.Common.Models;

namespace Application.Services;

public interface IUserService
{
    Task<UserInternalModel?> GetInternalModelByIdAsync(Guid id);
}