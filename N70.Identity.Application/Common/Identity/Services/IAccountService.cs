using N70.Identity.Domain.Entities;

namespace N70.Identity.Application.Common.Identity.Services;

public interface IAccountService
{
    ValueTask<bool> VerificateUserAsync(string token);

    ValueTask<User> CreateUserAsync(User user);
}