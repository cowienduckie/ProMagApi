using Domain.Base;
using Domain.Entities.WorkColumns;

namespace Domain.Entities.Projects;

public class Project : AuditableEntity<Guid>
{
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public ICollection<WorkColumn> WorkColumns { get; set; } = null!;
}