using Domain.Entities;

namespace Application.Objects
{
    public record AuthenticationResult(
        User User,
        string Token);
}
