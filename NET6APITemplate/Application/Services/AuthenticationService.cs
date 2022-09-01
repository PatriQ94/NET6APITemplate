using Application.Interfaces;
using Application.Objects;

namespace Application.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        public AuthenticationResult Login(string email, string password)
        {
            return new AuthenticationResult(Guid.NewGuid(), "FirstName", "LastName", email, "token");
        }

        public AuthenticationResult Register(string firstName, string lastName, string email, string password)
        {
            return new AuthenticationResult(Guid.NewGuid(), firstName, lastName, email, "token");
        }
    }
}
