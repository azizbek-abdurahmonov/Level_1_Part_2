using N63_HT1.Models.Entities;

namespace N63_HT1.Services;

public class FileService
{
    private string _userFolderPath;

    public FileService(IConfiguration configuration)
    {
        _userFolderPath = configuration.GetSection("Path:UserFolderPath").Value!;
    }

    public async ValueTask UploadAsync(IFormFile file, StorageFile storageFile)
    {
        var userFolderPath = _userFolderPath.Replace("{{UserId}}", storageFile.UserId.ToString());

        if (!Directory.Exists(userFolderPath))
            Directory.CreateDirectory(userFolderPath);

        var filePath = Path.Combine(userFolderPath, $"{storageFile.Id}{storageFile.Extension}");

        if (File.Exists(filePath))
            throw new ArgumentException("File is already exists!");

        using var stream = File.Create(filePath);

        await file.CopyToAsync(stream);
    }
}
