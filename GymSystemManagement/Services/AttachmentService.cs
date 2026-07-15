using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;

public class AttachmentService : IAttachmentService
{
    private readonly IWebHostEnvironment _environment;

    public AttachmentService(IWebHostEnvironment environment)
    {
        _environment = environment;
    }

    public async Task<string?> UploadAsync(IFormFile? file, string folderName)
    {
        if (file == null || file.Length == 0)
            return null;

        string webRootPath = _environment.WebRootPath;

        if (string.IsNullOrEmpty(webRootPath))
            throw new Exception("wwwroot folder not found.");

        string folderPath = Path.Combine(webRootPath, "Images", folderName);

        if (!Directory.Exists(folderPath))
            Directory.CreateDirectory(folderPath);

        string extension = Path.GetExtension(file.FileName);

        string fileName = $"{Guid.NewGuid()}{extension}";

        string filePath = Path.Combine(folderPath, fileName);

        using (FileStream stream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        return fileName;
    }

    public void Delete(string? fileName, string folderName)
    {
        if (string.IsNullOrWhiteSpace(fileName))
            return;

        string webRootPath = _environment.WebRootPath;

        if (string.IsNullOrEmpty(webRootPath))
            return;

        string filePath = Path.Combine(webRootPath, "Images", folderName, fileName);

        if (File.Exists(filePath))
        {
            File.Delete(filePath);
        }
    }
}