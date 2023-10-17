using N56_HT1.Interfaces;
using N56_HT1.Models;

namespace N56_HT1.Services;

public class CleanUpService : ICleanUpService
{
    private readonly IDirectoryService _directoryService;
    private readonly IFileService _fileService;

    public CleanUpService(IDirectoryService directoryService, IFileService fileService)
    {
        _directoryService = directoryService;
        _fileService = fileService;
    }

    public async ValueTask<List<string>> CleanAsync(User user)
    {
        var absolutePath = Path.Combine(Directory.GetCurrentDirectory(), "User", user.Id.ToString());

        await CleanProfileFolderAsync(Path.Combine(absolutePath, "Profile"));

        return await CleanResumeFolderAsync(Path.Combine(absolutePath, "Resume"));
    }

    private ValueTask CleanProfileFolderAsync(string path)
    {
        var validImageFileExtensions = new List<string>
        {
            ".png",
            ".jpg",
            ".webm"
        };

        foreach (var file in _directoryService.GetFiles(path))
        {
            if (!validImageFileExtensions.Contains(_fileService.GetFileExtension(file))
                || (_fileService.GetFileSize(file) / 1024) <= 60)
            {
                _fileService.DeleteFile(file);
            }
        }

        return ValueTask.CompletedTask;
    }

    private ValueTask<List<string>> CleanResumeFolderAsync(string path)
    {
        var validDocumentExtenions = new List<string>
        {
            ".pdf",
            ".docx",
            ".txt",
        };



        var invalidDocuments = new List<string>();

        foreach (var file in _directoryService.GetFiles(path))
        {
            if (!validDocumentExtenions.Contains(_fileService.GetFileExtension(file)))
                invalidDocuments.Add(file);
        }

        return new ValueTask<List<string>>(invalidDocuments);
    }
}
