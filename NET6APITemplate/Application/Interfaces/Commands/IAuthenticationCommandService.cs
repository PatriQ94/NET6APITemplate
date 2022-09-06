using Application.Common.Objects;

namespace Application.Interfaces.Commands
{
    public interface IAuthenticationCommandService
    {
        AuthenticationResult Register(string firstName, string lastName, string email, string password);
    }
}
