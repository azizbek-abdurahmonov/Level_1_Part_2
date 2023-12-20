using N90_HT1.Domain.Entities;

namespace N90_HT1.Application.Common.Identity.Services;

public interface IAccessTokenGeneratorService
{
    AccessToken GetToken(User user);

    Guid GetTokenId(string accessToken);
}