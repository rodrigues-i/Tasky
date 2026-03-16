using Tasky.Domain.Entities;

namespace Tasky.Api.Endpoints
{
    public static class ProjectEndpoints
    {
        public static void MapProjectEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapGet("/projects", () =>
            {
                var user1 = new User(Guid.NewGuid(), "Lucas");
                var user2 = new User(Guid.NewGuid(), "João");
                var user3 = new User(Guid.NewGuid(), "Pedro");
                var user4 = new User(Guid.NewGuid(), "Mateus");

                var users = new List<User> { user1, user2, user3, user4 };

                return Results.Ok(users);
            })
                .WithName("GetUsers")
                .WithOpenApi();
        }
    }
}
