using N56_HT1.Interfaces;
using System.Linq.Expressions;

namespace N56_HT1.Services;

public class DirectoryService : IDirectoryService
{
    public IEnumerable<string> GetFiles(string path)
    {
        return Directory.EnumerateFiles(path);
    }
}
