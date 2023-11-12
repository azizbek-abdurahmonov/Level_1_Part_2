using N70.Identity.Application.Common.Identity.Services;
using BC = BCrypt.Net.BCrypt;

namespace N70.Identity.Infrastructure.Common.Identity.Services;

public class PasswordHasherService : IPasswordHasherService
{
    public string Hash(string password) => BC.HashPassword(password);

    public bool Verify(string password, string passwordHash) => BC.Verify(password, passwordHash);
}