using Microsoft.AspNetCore.Http;

namespace ECommerceMVC.Infrastructure.FileService
{
    public interface IFileSaver
    {
        Task<string> SaveFile(IFormFile file);
    }
}