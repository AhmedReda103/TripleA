using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;

namespace TripleA.Service.Abstracts
{
    public interface IPhotoService
    {
        Task<ImageUploadResult> AddPhotoAsync(IFormFile file);

        Task<DeletionResult> DeletePhotoAsync(string publicUrl);
    }
}