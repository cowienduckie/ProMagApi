using Application.Common.Models;

namespace Application.Dtos.Projects;

public class GetProjectListResponse : PagedList<GetProjectResponse>
{
    public GetProjectListResponse(IQueryable<GetProjectResponse> source, int pageIndex, int pageSize)
        : base(source, pageIndex, pageSize)
    {
    }
}