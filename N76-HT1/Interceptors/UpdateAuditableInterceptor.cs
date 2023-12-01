using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using N76_HT1.Models.Common;

namespace N76_HT1.Interceptors;

public class UpdateAuditableInterceptor : SaveChangesInterceptor
{
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        var auditableEntities = eventData.Context!.ChangeTracker.Entries<IAuditableEntity>().ToList();

        auditableEntities.ForEach(entry =>
        {
            if (entry.State == EntityState.Added)
            {
                entry.Property(nameof(IAuditableEntity.CreatedTime)).CurrentValue = DateTime.UtcNow;
            }

            if (entry.State == EntityState.Modified)
            {
                entry.Property(nameof(IAuditableEntity.ModifiedTime)).CurrentValue = DateTime.UtcNow;
            }
        });

        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }
}
