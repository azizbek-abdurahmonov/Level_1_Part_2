using N56_HT1.Interfaces;
using System.Linq.Expressions;

namespace N56_HT1.Services;

public class FileService : IFileService
{
    public bool DeleteFile(string path)
    {
        if (File.Exists(path))
        {
            File.Delete(path);
            return true;
        }
        return false;
    }

    public string GetFileExtension(string path)
        => Path.GetExtension(path);

    public long GetFileSize(string path)
        => new FileInfo(path).Length;
}
