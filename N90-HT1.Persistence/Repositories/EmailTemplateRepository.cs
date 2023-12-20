using System.Linq.Expressions;
using N90_HT1.Domain.Entities;
using N90_HT1.Persistence.Caching.Brokers;
using N90_HT1.Persistence.DataContexts;
using N90_HT1.Persistence.Repositories.Interfaces;

namespace N90_HT1.Persistence.Repositories;

public class EmailTemplateRepository(NotificationDbContext dbContext, ICacheBroker cacheBroker)
    : EntityRepositoryBase<EmailTemplate, NotificationDbContext>(dbContext, cacheBroker), IEmailTemplateRepository
{
    public new IQueryable<EmailTemplate> Get(Expression<Func<EmailTemplate, bool>>? predicate = default, bool asNoTracking = false)
    {
        return base.Get(predicate, asNoTracking);
    }

    public new ValueTask<EmailTemplate> CreateAsync(
        EmailTemplate emailTemplate,
        bool saveChanges = true,
        CancellationToken cancellationToken = default
    )
    {
        return base.CreateAsync(emailTemplate, saveChanges, cancellationToken);
    }
}