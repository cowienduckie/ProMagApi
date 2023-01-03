namespace Application.Dtos.Projects;

public class GetProjectRequest
{
    public GetProjectRequest(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; set; }
}