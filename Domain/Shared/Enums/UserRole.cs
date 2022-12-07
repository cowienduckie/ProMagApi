using System.ComponentModel;

namespace Domain.Shared.Enums;

public enum UserRole
{
    [Description("Project Manager")] ProjectManager,
    [Description("Team Member")] TeamMember
}