using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using TripleA.Service.Abstracts;

namespace TripleA.Service.implementations
{
    public class FileService : IFileService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public FileService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task<string> UploadFile(string location, IFormFile? file)
        {
            if (file == null)
            {
                return "NOFile";
            }

            var path = _webHostEnvironment.WebRootPath + "/" + location + "/";
            var extention = Path.GetExtension(file.FileName);
            var fileName = Guid.NewGuid().ToString().Replace("-", string.Empty) + extention;
            if (file.Length > 0)
            {
                try
                {
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    using (FileStream fileStream = File.Create(path + fileName))
                    {
                        await file.CopyToAsync(fileStream);
                        await fileStream.FlushAsync();  //remove for puffer
                        return $"{path + fileName}";
                    }
                }
                catch (Exception)
                {
                    return "FailedToUploadFile";
                }

            }
            else
            {
                return "NoFile";
            }
        }
    }
}


