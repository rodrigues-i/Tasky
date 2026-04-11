using Tasky.Api.DTOs;
using Tasky.Application.Interfaces;

namespace Tasky.Api.Endpoints
{
    public static class AuthEndpoints
    {
        public static void MapAuthEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapPost("/auth/register", async (RegisterRequest request, IAuthService authService) =>
            {
                await authService.Register(request.Name, request.Email, request.Password);
                return Results.Ok();
            });

            app.MapPost("/auth/login", (LoginRequest request, IAuthService authService) =>
            {
                var result = authService.Login(request.Email, request.Password);
                if (!result.IsSuccess)
                    return Results.Json(
                        new { error = result.Error?.Message },
                        statusCode: 401
                     );
                return Results.Ok(result.Value);
            });
        }
    }
}
