using Microsoft.AspNetCore.Http;

namespace TripleA.Service.Abstracts
{
    public interface IFileService
    {
        public Task<string> UploadFile(string location, IFormFile file);
    }
}
