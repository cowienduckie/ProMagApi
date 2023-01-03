using Domain.Shared.Enums;

namespace Application.Common.Models;

public class UserInternalModel
{
    public Guid Id { get; set; }

    public string Username { get; set; } = null!;

    public UserRole Role { get; set; }
}