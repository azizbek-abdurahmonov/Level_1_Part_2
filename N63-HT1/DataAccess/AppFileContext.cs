using FileBaseContext.Abstractions.Models.FileContext;
using FileBaseContext.Abstractions.Models.FileSet;
using FileBaseContext.Context.Models.Configurations;
using FileBaseContext.Context.Models.FileContext;
using N63_HT1.Models.Entities;

namespace N63_HT1.DataAccess;

public class AppFileContext : FileContext, IDataContext
{
    public IFileSet<User, Guid> Users => Set<User, Guid>(nameof(Users));

    public IFileSet<StorageFile, Guid> StorageFiles => Set<StorageFile, Guid>(nameof(StorageFiles));

    public AppFileContext(IFileContextOptions<IFileContext> fileContextOptions) : base(fileContextOptions)
    {

    }
}
