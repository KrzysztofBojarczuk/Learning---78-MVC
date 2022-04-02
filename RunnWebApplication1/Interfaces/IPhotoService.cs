using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;

namespace RunnWebApplication1.Interfaces
{
    public interface IPhotoService
    {
        Task<ImageUploadResult> AddPhotoAsync(IFormFile file);
        Task<DeletionResult> DeletePhotoAsync(string publicId);
    }
}
