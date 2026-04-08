using Tasky.Api.DTOs;
using Tasky.Application.Interfaces;

namespace Tasky.Api.Endpoints
{
    public static class UserEndpoints
    {
        public static void MapUserEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapPost("/users", async (RegisterRequest createUserRequest, IUserService service) =>
            {
                await service.CreateUser(createUserRequest.Name, createUserRequest.Email, createUserRequest.Password);
                return Results.Ok();
            });

            app.MapGet("/users", (IUserService service) =>
            {
                var users = service.GetAllUsers();
                return Results.Ok(users);
            });
        }
    }
}
