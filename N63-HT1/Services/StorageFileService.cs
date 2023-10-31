using N63_HT1.DataAccess;
using N63_HT1.Interfaces;
using N63_HT1.Models.Entities;
using System.Linq.Expressions;

namespace N63_HT1.Services;

public class StorageFileService : IStorageFileService
{
    private readonly IDataContext _context;

    public StorageFileService(IDataContext context)
    {
        _context = context;
    }

    public async ValueTask<StorageFile> CreateAsync(StorageFile storageFile)
    {
        await _context.StorageFiles.AddAsync(storageFile);
        await _context.SaveChangesAsync();

        return storageFile;
    }

    public IQueryable<StorageFile> Get(Expression<Func<StorageFile, bool>> predicate)
        => _context.StorageFiles.Where(predicate.Compile()).AsQueryable();   
}
