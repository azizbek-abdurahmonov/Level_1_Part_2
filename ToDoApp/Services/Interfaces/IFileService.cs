namespace ToDoApp.Services.Interfaces;

public interface IFileService
{
    string FolderName { get; }
    ValueTask<string> SaveImageAsync(IFormFile image);
    ValueTask<bool> DeleteAsync(string path);
}
