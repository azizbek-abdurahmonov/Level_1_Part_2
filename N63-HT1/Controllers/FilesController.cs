using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using N63_HT1.Interfaces;
using N63_HT1.Models.Constants;
using N63_HT1.Models.Entities;
using N63_HT1.Services;

namespace N63_HT1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FilesController : ControllerBase
{
    private readonly FileService _fileService;
    private readonly IStorageFileService _storageFileService;

    public FilesController(FileService fileService, IStorageFileService storageFileService)
    {
        _fileService = fileService;
        _storageFileService = storageFileService;
    }

    [Authorize]
    [HttpPost("upload")]
    public async ValueTask<IActionResult> UploadFile()
    {
        var files = Request.Form.Files.ToList();

        var userId = User.Claims.FirstOrDefault(claim => claim.Type == ClaimConstants.UserId)!.Value;

        foreach (var file in files)
        {
            var storageFile = new StorageFile
            {
                Id = Guid.NewGuid(),
                Name = file.FileName,
                UserId = Guid.Parse(userId),
                Extension = Path.GetExtension(file.FileName)
            };

            await _storageFileService.CreateAsync(storageFile);
            await _fileService.UploadAsync(file, storageFile);
        }
        return Ok();
    }

    [Authorize]
    [HttpGet]
    public IActionResult GetTemp()
    {
        return Ok("Hi barbie!");
    }
}
