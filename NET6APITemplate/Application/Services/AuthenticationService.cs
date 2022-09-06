using Application.Common.Interfaces;
using Application.Interfaces;
using Application.Interfaces.Persistence;
using Application.Objects;
using Domain.Entities;

namespace Application.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        public AuthenticationResult Register(string firstName, string lastName, string email, string password)
        {
            //Validatee the user doesn't exist
            if (_userRepository.GetUserByEmail(email) is not null)
            {
                throw new Exception("User with given email already exists.");
            }

            //Create user (generate unique ID)
            var user = new User()
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Password = password
            };

            _userRepository.Add(user);

            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(user, token);
        }

        public AuthenticationResult Login(string email, string password)
        {
            //Validate the user exists
            if (_userRepository.GetUserByEmail(email) is not User user)
            {
                throw new Exception($"User with given email does not exist.");
            }

            //Validate
            if (user.Password != password)
            {
                throw new Exception($"Invalid password");
            }

            //Generate token
            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(user, token);
        }
    }
}
