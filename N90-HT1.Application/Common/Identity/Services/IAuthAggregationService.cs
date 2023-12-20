using N90_HT1.Application.Common.Identity.Models;

namespace N90_HT1.Application.Common.Identity.Services;

public interface IAuthAggregationService
{
    ValueTask<bool> SignUpAsync(SignUpDetails signUpDetails, CancellationToken cancellationToken = default);
}