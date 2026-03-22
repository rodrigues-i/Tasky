namespace Tasky.Application.DTOs
{
    public record TaskDto(
        Guid Id,
        string Title,
        Guid? AssignedUserId
    );
}
