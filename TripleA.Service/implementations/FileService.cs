using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using TripleA.Data.Entities;
using TripleA.Service.Abstracts;

namespace TripleA.Service.implementations
{
    public class FileService : IFileService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        //private readonly ILogger<FileService> _logger;

        public FileService(IWebHostEnvironment webHostEnvironment, ILogger<FileService> logger)
        {
            _webHostEnvironment = webHostEnvironment;
            //_logger = logger;
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


        public bool DeleteFile(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                    //_logger.LogInformation($"File deleted: {filePath}");
                    Debug.WriteLine($"File deleted: {filePath}");
                    return true;
                }
                else
                {
                    //_logger.LogWarning($"File not found: {filePath}");
                    Debug.WriteLine($"File not found: {filePath}");
                    return false;
                }
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex, $"Error deleting file: {filePath}");
                Debug.WriteLine($"Error deleting file:  {filePath}");
                return false;
            }
        }

        public void SetQuestionFilePath(string fileUrl, Question question)
        {
            if (fileUrl == "NoFile" || fileUrl == "FailedToUploadFile")
            {
                question.Image = fileUrl;
            }
            else
            {
                question.Image = fileUrl;
            }
        }
    }
}


