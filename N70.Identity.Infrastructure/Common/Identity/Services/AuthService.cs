using System.Globalization;
using Microsoft.EntityFrameworkCore;
using N70.Identity.Application.Common.Identity.Models;
using N70.Identity.Application.Common.Identity.Services;
using N70.Identity.Application.Common.Notifications.Services;
using N70.Identity.Domain.Entities;
using N70.Identity.Domain.Enums;

namespace N70.Identity.Infrastructure.Common.Identity.Services;

public class AuthService : IAuthService
{
    private readonly IAccountService _accountService;
    private readonly IEmailOrchestrationService _emailOrchestrationService;
    private readonly ITokenGeneratorService _tokenGeneratorService;
    private readonly IPasswordHasherService _passwordHasherService;
    private readonly IUserService _userService;
    private readonly IRoleService _roleService;

    public AuthService(
        IAccountService accountService,
        IEmailOrchestrationService emailOrchestrationService,
        ITokenGeneratorService tokenGeneratorService,
        IPasswordHasherService passwordHasherService,
        IUserService userService,
        IRoleService roleService)
    {
        _accountService = accountService;
        _emailOrchestrationService = emailOrchestrationService;
        _tokenGeneratorService = tokenGeneratorService;
        _passwordHasherService = passwordHasherService;
        _userService = userService;
        _roleService = roleService;
    }

    public async ValueTask<bool> RegisterAsync(RegistrationDetails registrationDetails)
    {
        await ValidateRegistrationDetailsAsync(registrationDetails);

        var user = new User()
        {
            FirstName = registrationDetails.FirstName,
            LastName = registrationDetails.LastName,
            EmailAddress = registrationDetails.EmailAddress,
            PasswordHash = _passwordHasherService.Hash(registrationDetails.Password),
            RoleId = Guid.Parse("7d07ea1f-9be7-48f0-ad91-5b83a5806baf")
        };

        await _accountService.CreateUserAsync(user);
        var result = await _emailOrchestrationService.SendAsync(user.EmailAddress, "Sistemaga xush kelibsiz!");

        return result;
    }

    public ValueTask<string> LoginAsync(LoginDetails loginDetails)
    {
        var temp = _userService.Get(s => true).Include(user => user.Role).ToList();
        
        var found = _userService.Get(user => user.EmailAddress == loginDetails.EmailAddress).FirstOrDefault()
                    ?? throw new InvalidOperationException("User not found!");

        if (!_passwordHasherService.Verify(loginDetails.Password, found.PasswordHash))
            throw new InvalidOperationException("Password is incorrect");

        var token = _tokenGeneratorService.GetToken(found);

        return new(token);
    }

    public async ValueTask<bool> GrandRoleAsync(Guid userId, string roleType, Guid actionUserId)
    {
        var user = await _userService.GetByIdAsync(userId) ?? throw new InvalidOperationException();
        _ = await _userService.GetByIdAsync(actionUserId) ?? throw new InvalidOperationException();

        if (!Enum.TryParse(roleType, out RoleType roleValue)) throw new InvalidOperationException();
        var role = await _roleService.GetByTypeAsync(roleValue) ??
                   throw new InvalidOperationException("Invalid role type");

        user.RoleId = role.Id;

        await _userService.UpdateAsync(user);

        return true;
    }

    private ValueTask ValidateRegistrationDetailsAsync(RegistrationDetails registrationDetails)
    {
        if (string.IsNullOrWhiteSpace(registrationDetails.Password)
            || registrationDetails.Password.Length < 8)
        {
            throw new ArgumentException("Invalid password");
        }

        return ValueTask.CompletedTask;
    }
}