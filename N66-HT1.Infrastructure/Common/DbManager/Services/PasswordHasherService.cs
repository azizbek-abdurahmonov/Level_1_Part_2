using N66_HT1.Application.Common.DbManager.Services;
using BC = BCrypt.Net.BCrypt;

namespace N66_HT1.Infrastructure.Common.DbManager.Services;

public class PasswordHasherService : IPasswordHasherService
{
    public string Hash(string password)
        => BC.HashPassword(password);

    public bool Verify(string password, string passwordHash)
        => BC.Verify(password, passwordHash);
}
