using Domain.Entities;

namespace Application.Common.Objects
{
    public record AuthenticationResult(
        User User,
        string Token);
}
