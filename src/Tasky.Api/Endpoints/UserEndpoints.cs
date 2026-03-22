using Tasky.Api.DTOs;
using Tasky.Application.Interfaces;

namespace Tasky.Api.Endpoints
{
    public static class UserEndpoints
    {
        public static void MapUserEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapPost("/users", (CreateUserRequest createUserRequest, IUserService service) =>
            {
                service.CreateUser(createUserRequest.name, createUserRequest.email, createUserRequest.password);
            });
        }
    }
}
