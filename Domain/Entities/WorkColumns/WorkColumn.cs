using Domain.Base;
using Domain.Entities.Projects;
using Domain.Entities.WorkItems;

namespace Domain.Entities.WorkColumns;

public class WorkColumn : AuditableEntity<Guid>
{
    public string Name { get; set; } = null!;
    public int Position { get; set; }
    public Guid ProjectId { get; set; }
    public Project Project { get; set; } = null!;
    public ICollection<WorkItem> WorkItems { get; set; } = null!;
}