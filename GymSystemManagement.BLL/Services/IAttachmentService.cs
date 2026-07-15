using Microsoft.AspNetCore.Http;

public interface IAttachmentService
{
    Task<string?> UploadAsync(IFormFile file, string folderName);

    void Delete(string fileName, string folderName);
}