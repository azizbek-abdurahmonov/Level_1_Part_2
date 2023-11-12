namespace N70.Identity.Application.Common.Identity.Services;

public interface IPasswordHasherService
{
    string Hash(string password);

    bool Verify(string password, string passwordHash);
}