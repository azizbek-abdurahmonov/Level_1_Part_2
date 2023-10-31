using N64.Identity.Application.Common.Identity.Services;
using BC = BCrypt.Net.BCrypt;

namespace N64.Identity.Infrastructure.Common.Identity.Services;

public class PasswordHasherService : IPasswordHasherService
{
    public string HashPassword(string password) => BC.HashPassword(password);

    public bool Verify(string password, string hash) => BC.Verify(password, hash);
}
