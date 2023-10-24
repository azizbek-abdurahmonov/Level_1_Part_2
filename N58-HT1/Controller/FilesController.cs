using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using N58_HT1.Models;
using System.IO;

namespace N58_HT1.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        [HttpGet]
        public ValueTask<IActionResult> GetFiles([FromQuery] FilterModel filterModel, [FromServices] IWebHostEnvironment environment)
        {
            var allFiles = new List<StorageFile>();

            var files = GetAllFiles(environment.WebRootPath, allFiles)
                .Skip((filterModel.PageToken - 1) * filterModel.PageSize)
                .Take(filterModel.PageSize);

            return new ValueTask<IActionResult>(Ok(files));

        }

        private IList<StorageFile> GetAllFiles(string path, List<StorageFile> allFiles)
        {
            var files = new DirectoryInfo(path).GetFiles().ToList();

            var directories = Directory.GetDirectories(path);

            allFiles.AddRange(files.Select(fileInfo => new StorageFile
            {
                Name = fileInfo.Name,

                Path = fileInfo.FullName,

                Directory = fileInfo.DirectoryName!,

                Extension = fileInfo.Extension,

                Size = fileInfo.Length,
            }));

            foreach (var directory in directories)
                GetAllFiles(directory, allFiles);

            return allFiles;
        }
    }
}