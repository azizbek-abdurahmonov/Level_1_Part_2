using Mapster;
using N66_HT1.Application.Common.DbManager.Models;
using N66_HT1.Application.Common.DbManager.Services;
using N66_HT1.Domain.Entities;

namespace N66_HT1.Infrastructure.Common.DbManager.Services;

public class AuthService : IAuthService
{
    private readonly ITokenGeneratorService _tokenGeneratorService;
    private readonly IUserService _userService;
    private readonly IPasswordHasherService _passwordHasherService;

    public AuthService(ITokenGeneratorService tokenGeneratorService, IUserService userService, IPasswordHasherService passwordHasherService)
    {
        _tokenGeneratorService = tokenGeneratorService;
        _userService = userService;
        _passwordHasherService = passwordHasherService;
    }

    public ValueTask<string> LoginAsync(LoginDetails loginDetails)
    {
        var found = _userService.Get(user => user.Email == loginDetails.Email
                && _passwordHasherService.Verify(loginDetails.Password, user.PasswordHash)).FirstOrDefault()
                ?? throw new InvalidOperationException("Email or password incorrect!");

        var token = _tokenGeneratorService.GetToken(found);

        return new(token);
    }

    public async ValueTask<bool> RegisterAsync(RegistrationDetails registrationDetails)
    {
        var user = registrationDetails.Adapt<User>();
        user.PasswordHash = _passwordHasherService.Hash(registrationDetails.Password);

        var result = await _userService.CreateAsync(user);

        return result is not null;
    }
}
