using System.ComponentModel.DataAnnotations;

namespace ToDoApp.Models;

public class UploadImageDto
{
    [Required]
    public IFormFile Image { get; set; }
}
