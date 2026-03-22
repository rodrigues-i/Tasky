namespace Tasky.Api.DTOs
{
    public record CreateTaskRequest(
        Guid projectId,
        string title
     );
}