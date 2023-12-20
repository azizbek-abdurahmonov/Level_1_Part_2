using N90_HT1.Domain.Entities;

namespace N90_HT1.Application.Common.Identity.Services;

public interface IPasswordGeneratorService
{
    string GeneratePassword();

    string GetValidatedPassword(string password, User user);
}