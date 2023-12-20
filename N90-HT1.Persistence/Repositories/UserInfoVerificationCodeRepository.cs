using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using N90_HT1.Domain.Entities;
using N90_HT1.Persistence.Caching.Brokers;
using N90_HT1.Persistence.DataContexts;
using N90_HT1.Persistence.Repositories.Interfaces;

namespace N90_HT1.Persistence.Repositories;

public class UserInfoVerificationCodeRepository(IdentityDbContext identityDbContext, ICacheBroker cacheBroker)
    : EntityRepositoryBase<UserInfoVerificationCode, IdentityDbContext>(identityDbContext, cacheBroker), IUserInfoVerificationCodeRepository
{
    public new IQueryable<UserInfoVerificationCode> Get(
        Expression<Func<UserInfoVerificationCode, bool>>? predicate = default,
        bool asNoTracking = false
    )
    {
        return base.Get(predicate, asNoTracking);
    }

    public new ValueTask<UserInfoVerificationCode?> GetByIdAsync(
        Guid codeId,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default
    )
    {
        return base.GetByIdAsync(codeId, asNoTracking, cancellationToken);
    }

    public new async ValueTask<UserInfoVerificationCode> CreateAsync(
        UserInfoVerificationCode verificationCode,
        bool saveChanges = true,
        CancellationToken cancellationToken = default
    )
    {
        await DbContext.UserInfoVerificationCodes.Where(code => code.UserId == verificationCode.UserId && code.CodeType == verificationCode.CodeType)
            .ExecuteUpdateAsync(setter => setter.SetProperty(code => code.IsActive, false), cancellationToken);

        return await base.CreateAsync(verificationCode, saveChanges, cancellationToken);
    }

    public async ValueTask DeactivateAsync(Guid codeId, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        await DbContext.UserInfoVerificationCodes.Where(code => code.Id == codeId)
            .ExecuteUpdateAsync(setter => setter.SetProperty(code => code.IsActive, false), cancellationToken);

        if (saveChanges)
            await DbContext.SaveChangesAsync(cancellationToken);
    }
}