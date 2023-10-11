using FileBaseContext.Abstractions.Models.FileSet;
using N52_HT1.Models;

namespace N52_HT1.DataAccess;

public interface IDataContext
{
    IFileSet<User, Guid> Users { get; }

    ValueTask SaveChangesAsync();
}