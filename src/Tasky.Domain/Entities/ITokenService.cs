namespace Tasky.Domain.Entities
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}
