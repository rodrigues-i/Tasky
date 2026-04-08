namespace Tasky.Application.Interfaces
{
    public interface IAuthService
    {
        Task Register(string name, string email, string password);
        string Login(string email, string password);
    }
}
