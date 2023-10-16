namespace N55_HT1.Services;

public class FileService
{
    public void CopyFileToCurrentFolder(string path, string destPath)
    {
        if (!Path.Exists(path))
            throw new ArgumentException("Source path isn't exists!");

        File.Copy(path, Path.Combine(destPath, Path.GetFileName(path)));
    }

    public int GetFilesCount(string path) => Directory.GetFiles(path).Length;

    public int GetDirectoriesCount(string path) => Directory.GetDirectories(path).Length;

    public decimal GetTotalSize(string path) => Directory.GetFiles(path).Sum(file => new FileInfo(file).Length);

    public string GetBiggestFile(string path) => Directory.GetFiles(path).MaxBy(file => new FileInfo(file).Length)!;
}