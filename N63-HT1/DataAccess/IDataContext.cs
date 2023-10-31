using FileBaseContext.Abstractions.Models.FileSet;
using FileBaseContext.Set.Models.FileSet;
using N63_HT1.Models.Entities;

namespace N63_HT1.DataAccess;

public interface IDataContext
{
    IFileSet<User, Guid> Users { get; }

    IFileSet<StorageFile, Guid> StorageFiles { get; }

    ValueTask SaveChangesAsync();

}
