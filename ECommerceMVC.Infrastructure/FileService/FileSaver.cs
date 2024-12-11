using Microsoft.AspNetCore.Http;

namespace ECommerceMVC.Infrastructure.FileService;

public class FileSaver : IFileSaver
{
    public async Task<string> SaveFile(IFormFile file)
    {
        if (file != null && file.Length > 0)
        {
            // Ensure the directory exists
            var directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            var fileName = Path.GetFileName(file.FileName);
            var filePath = Path.Combine(directoryPath, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            // Return the relative path to the image
            return $"/images/{fileName}";
        }

        return null;
    }
}