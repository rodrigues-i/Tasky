namespace Tasky.Api.DTOs
{
    public record CreateUserRequest(string name, string email, string password);
}
