using N53_HT1.Api.Models;
using System.Linq.Expressions;

namespace N53_HT1.Api.Interfaces;

public interface IBonusService
{
    IQueryable<Bonus> Get(Expression<Func<Bonus, bool>> predicate);

    ValueTask<Bonus> CreateAsync(Bonus bonus);

    ValueTask<Bonus> UpdateAsync(Bonus bonus);
}
