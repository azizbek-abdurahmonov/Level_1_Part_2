using System.Linq.Expressions;

namespace N56_HT1.Interfaces;

public interface IDirectoryService
{
    IEnumerable<string> GetFiles(string path);
}
