using N90_HT1.Domain.Common.Query;
using N90_HT1.Domain.Entities;

namespace N90_HT1.Application.Common.Notifications.Services;

public interface IEmailHistoryService
{
    ValueTask<IList<EmailHistory>> GetByFilterAsync(
        FilterPagination paginationOptions,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default
    );

    ValueTask<EmailHistory> CreateAsync(EmailHistory emailHistory, bool saveChanges = true, CancellationToken cancellationToken = default);
}