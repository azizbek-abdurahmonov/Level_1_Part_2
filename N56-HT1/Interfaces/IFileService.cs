using System.Linq.Expressions;

namespace N56_HT1.Interfaces;

public interface IFileService
{
    string GetFileExtension(string path);

    long GetFileSize(string path);

    bool DeleteFile(string path);
}
