using CloneGramm.Library.Models;
using FileBaseContext.Abstractions.Models.FileSet;

namespace CloneGramm.Library.DataAccess;

public interface IDataContext
{
    IFileSet<User, Guid> Users { get; }
    IFileSet<Post, Guid> Posts { get; }

    ValueTask SaveChangesAsync();
}