using Tasky.Api.DTOs;
using Tasky.Application.Interfaces;
using Tasky.Domain.Entities;

namespace Tasky.Api.Endpoints
{
    public static class ProjectEndpoints
    {
        public static void MapProjectEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapGet("/projects", (IProjectService service) =>
            {
                var projects = service.GetAllProjects();
                return Results.Ok(projects);
            });

            app.MapPost("/projects", (CreateProjectRequest createProjectRequest, IProjectService service) =>
            {
                service.CreateProject(createProjectRequest.name);
                return Results.Ok();
            });
        }
    }
}
