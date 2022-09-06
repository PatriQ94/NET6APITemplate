using Application.Common.Objects;

namespace Application.Interfaces.Queries
{
    public interface IAuthenticationQueryService
    {
        AuthenticationResult Login(string email, string password);
    }
}
