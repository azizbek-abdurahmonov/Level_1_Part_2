using N90_HT1.Domain.Entities;

namespace N90_HT1.Application.Common.Identity.Services;

public interface IAccountAggregatorService
{
    ValueTask<bool> CreateUserAsync(User user, CancellationToken cancellationToken = default);
}