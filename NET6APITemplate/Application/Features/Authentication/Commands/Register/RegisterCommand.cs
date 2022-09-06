using Application.Common.Objects;
using MediatR;

namespace Application.Features.Authentication.Commands.Register
{
    public record RegisterCommand(
        string FirstName,
        string LastName,
        string Email,
        string Password) : IRequest<AuthenticationResult>;
}
