using N53_HT1.Api.DataAccess;
using N53_HT1.Api.Interfaces;
using N53_HT1.Api.Models;
using System.Linq.Expressions;

namespace N53_HT1.Api.Services;

public class BonusService : IBonusService
{
    private readonly IDataContext _context;

    public BonusService(IDataContext context)
    {
        _context = context;
    }

    public async ValueTask<Bonus> CreateAsync(Bonus bonus)
    {
        var entity = await _context.Bonuses.AddAsync(bonus);

        await _context.SaveChangesAsync();

        return entity.Entity;
    }

    public IQueryable<Bonus> Get(Expression<Func<Bonus, bool>> predicate)
        => _context.Bonuses.Where(predicate.Compile()).AsQueryable();

    public async ValueTask<Bonus> UpdateAsync(Bonus bonus)
    {
        var found = _context.Bonuses.FirstOrDefault(x => x.Id == bonus.Id);

        if (found == null)
            throw new Exception("Bonus not found!");

        found.Amount = bonus.Amount;

        await _context.SaveChangesAsync();

        return bonus;
    }
}
