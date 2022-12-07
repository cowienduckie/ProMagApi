using Domain.Entities.Users;
using Domain.Shared.Enums;

namespace Application.Common.Models;

public class UserInternalModel
{
    public UserInternalModel(User user)
    {
        Id = user.Id;
        Username = user.Username;
        Role = user.Role;
    }

    public Guid Id { get; }

    public string Username { get; }

    public UserRole Role { get; }
}