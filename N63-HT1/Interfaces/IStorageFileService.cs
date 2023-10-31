using N63_HT1.Models.Entities;
using System.Linq.Expressions;

namespace N63_HT1.Interfaces;

public interface IStorageFileService
{
    ValueTask<StorageFile> CreateAsync(StorageFile storageFile);

    IQueryable<StorageFile> Get(Expression<Func<StorageFile, bool>> predicate);
}
