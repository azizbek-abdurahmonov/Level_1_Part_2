using Microsoft.AspNetCore.Http.HttpResults;
using N63_Task2.Models.Dtos;
using N63_Task2.Models.Entity;
using System.Security.Authentication;

namespace N63_Task2.Services;

public class AuthService
{
    private static List<User> _users = new();

    private readonly PasswordHasherService _hasherService;
    private readonly TokenGeneratorService _tokenGeneratorService;

    public AuthService(PasswordHasherService passwordHasherService, TokenGeneratorService tokenGeneratorService)
    {
        _hasherService = passwordHasherService;
        _tokenGeneratorService = tokenGeneratorService;
    }

    public ValueTask<bool> RegisterAsync(RegistrationDetails registrationDetails)
    {
        var user = new User
        {
            Id = Guid.NewGuid(),

            FirstName = registrationDetails.FirstName,

            LastName = registrationDetails.LastName,

            Email = registrationDetails.EmailAddress,

            Password = _hasherService.Hash(registrationDetails.Password),
        };

        _users.Add(user);

        return new ValueTask<bool>(true);
    }

    public ValueTask<string> LoginAsync(LoginDetails loginDetails)
    {
        var found = _users.FirstOrDefault(user => user.Email == loginDetails.Email
            && _hasherService.Verify(loginDetails.Password, user.Password))
            ?? throw new AuthenticationException("Login details are invalid!");

        return new ValueTask<string>(_tokenGeneratorService.GetToken(found));
    }
}
