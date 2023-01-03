using Domain.Entities.WorkColumns;

namespace Infrastructure.Persistence.Repositories;

public class WorkColumnRepository : RepositoryBase<WorkColumn>, IWorkColumnRepository
{
    public WorkColumnRepository(EfContext dbContext) : base(dbContext)
    {
    }
}