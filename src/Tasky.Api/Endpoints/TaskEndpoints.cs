using Tasky.Api.DTOs;
using Tasky.Application.Interfaces;

namespace Tasky.Api.Endpoints
{
    public static class TaskEndpoints
    {
        public static void MapTaskEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapPost("/tasks",async (CreateTaskRequest createTaskRequest, IProjectService service) =>
            {
                await service.CreateTask(createTaskRequest.projectId, createTaskRequest.title);
            });
        }
    }
}
