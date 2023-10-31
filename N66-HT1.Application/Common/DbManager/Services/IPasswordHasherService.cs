namespace N66_HT1.Application.Common.DbManager.Services;

public interface IPasswordHasherService
{
    string Hash(string password);

    bool Verify(string password, string passwordHash);
}
