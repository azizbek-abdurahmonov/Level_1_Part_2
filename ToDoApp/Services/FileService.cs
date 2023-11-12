using System.ComponentModel.Design.Serialization;
using ToDoApp.Services.Interfaces;

namespace ToDoApp.Services;

public class FileService : IFileService
{
    private readonly string _folderName = "images";
    private readonly string _basePath;

    public FileService(IWebHostEnvironment webHost)
    {
        _basePath = webHost.ContentRootPath;
    }

    public string FolderName => _folderName;

    public ValueTask<bool> DeleteAsync(string path)
    {
        throw new NotImplementedException();
    }

    public ValueTask<string> SaveImageAsync(IFormFile image)
    {
        var folderPath = Path.Combine(_basePath, _folderName);

        if (!Directory.Exists(_basePath))
            Directory.CreateDirectory(_basePath);

        if (!Directory.Exists(folderPath))
            Directory.CreateDirectory(folderPath);

        var stream = File.OpenRead(image.FileName);

        return new(image.FileName);
    }
}