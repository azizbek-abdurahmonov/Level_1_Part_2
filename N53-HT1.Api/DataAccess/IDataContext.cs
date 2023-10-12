using FileBaseContext.Abstractions.Models.FileSet;
using N53_HT1.Api.Models;

namespace N53_HT1.Api.DataAccess;

public interface IDataContext
{
    IFileSet<User, Guid> Users { get; }
    IFileSet<Order, Guid> Orders { get; }
    IFileSet<Bonus, Guid> Bonuses { get; }


    ValueTask SaveChangesAsync();
}
