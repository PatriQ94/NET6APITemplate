﻿using Application.Objects;

namespace Application.Interfaces
{
    public interface IAuthenticationService
    {
        AuthenticationResult Login(string email, string password);
        AuthenticationResult Register(string firstName, string lastName, string email, string password);
    }
}
