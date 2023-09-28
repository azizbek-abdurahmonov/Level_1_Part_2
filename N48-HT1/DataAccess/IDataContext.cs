using FileBaseContext.Abstractions.Models.FileSet;
using FileBaseContext.Set.Models.FileSet;
using N48_HT1.Models;

namespace N48_HT1.DataAccess;

public interface IDataContext
{
    IFileSet<User, Guid> Users { get; }
    IFileSet<Order, Guid> Orders { get; }
}
