using Domain.Base;
using Domain.Shared.Enums;

namespace Domain.Entities.Users;

public class User : AuditableEntity<Guid>
{
    public string Username { get; set; } = null!;

    public string HashedPassword { get; set; } = null!;

    public UserRole Role { get; set; }

    public string StaffCode { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string FullName => $"{FirstName} {LastName}";

    public DateTime DateOfBirth { get; set; }

    public Gender Gender { get; set; }
}