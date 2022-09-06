using Application.Common.Interfaces;
using Application.Common.Objects;
using Application.Common.Persistence;
using Domain.Entities;
using MediatR;

namespace Application.Features.Authentication.Queries.Login
{
    internal class LoginQueryHandler : IRequestHandler<LoginQuery, AuthenticationResult>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public LoginQueryHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        public async Task<AuthenticationResult> Handle(LoginQuery query, CancellationToken cancellationToken)
        {
            //Validate the user exists
            if (_userRepository.GetUserByEmail(query.Email) is not User user)
            {
                throw new Exception($"User with given email does not exist.");
            }

            //Validate
            if (user.Password != query.Password)
            {
                throw new Exception($"Invalid password");
            }

            //Generate token
            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(user, token);
        }
    }
}
