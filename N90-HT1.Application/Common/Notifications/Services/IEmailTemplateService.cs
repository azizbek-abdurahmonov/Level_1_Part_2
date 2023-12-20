using N90_HT1.Domain.Common.Query;
using N90_HT1.Domain.Entities;
using N90_HT1.Domain.Enums;

namespace N90_HT1.Application.Common.Notifications.Services;

public interface IEmailTemplateService
{
    ValueTask<IList<EmailTemplate>> GetByFilterAsync(
        FilterPagination paginationOptions,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default
    );

    ValueTask<EmailTemplate?> GetByTypeAsync(
        NotificationTemplateType templateType,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default
    );

    ValueTask<EmailTemplate> CreateAsync(EmailTemplate emailTemplate, bool saveChanges = true, CancellationToken cancellationToken = default);
}