using N66_HT1.Application.Common.DbManager.Models;

namespace N66_HT1.Application.Common.DbManager.Services;

public interface IAuthService
{
    ValueTask<bool> RegisterAsync(RegistrationDetails registrationDetails);

    ValueTask<string> LoginAsync(LoginDetails loginDetails);
}
