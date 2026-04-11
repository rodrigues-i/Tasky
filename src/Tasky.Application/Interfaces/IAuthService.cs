using Tasky.Application.Common;
using Tasky.Application.DTOs.Auth;

namespace Tasky.Application.Interfaces
{
    public interface IAuthService
    {
        Task Register(string name, string email, string password);
        Result<LoginResponse> Login(string email, string password);
    }
}
