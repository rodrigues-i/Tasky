using Tasky.Api.DTOs;
using Tasky.Application.Interfaces;
using Tasky.Domain.Entities;

namespace Tasky.Api.Endpoints
{
    public static class ProjectEndpoints
    {
        public static void MapProjectEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapGet("/projects", async (IProjectService service) =>
            {
                var projects = await service.GetAllProjects();
                return Results.Ok(projects);
            });

            app.MapPost("/projects", async (CreateProjectRequest createProjectRequest, IProjectService service) =>
            {
                await service.CreateProject(createProjectRequest.name);
                return Results.Ok();
            });
        }
    }
}
