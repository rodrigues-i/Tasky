using Tasky.Api.DTOs;
using Tasky.Application.Interfaces;

namespace Tasky.Api.Endpoints
{
    public static class UserEndpoints
    {
        public static void MapUserEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapPost("/users", async (CreateUserRequest createUserRequest, IUserService service) =>
            {
                await service.CreateUser(createUserRequest.name, createUserRequest.email, createUserRequest.password);
            });

            app.MapGet("/users", (IUserService service) =>
            {
                var users = service.GetAllUsers();
                return users;
            });
        }
    }
}
