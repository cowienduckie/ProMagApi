using Domain.Base;
using Domain.Entities.WorkColumns;

namespace Domain.Entities.WorkItems
{
    public class WorkItem : AuditableEntity<Guid>
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public bool IsCompleted { get; set; }
        public int Position { get; set; }
        public Guid WorkColumnId { get; set; }
        public WorkColumn WorkColumn { get; set; } = null!;
    }
}