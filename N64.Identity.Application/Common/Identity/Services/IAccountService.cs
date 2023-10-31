using N64.Identity.Domain.Entity;

namespace N64.Identity.Application.Common.Identity.Services;

public interface IAccountService
{
    List<User> Users { get; }

    ValueTask<User> CreateUserAsync(User user);

    ValueTask<bool> VerificateAsync(string token);
}
