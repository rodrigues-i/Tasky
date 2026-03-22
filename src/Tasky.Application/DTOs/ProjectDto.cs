namespace Tasky.Application.DTOs
{
    public record ProjectDto(
        Guid ProjectId,
        string Name,
        List<TaskDto> Tasks
    );
}
