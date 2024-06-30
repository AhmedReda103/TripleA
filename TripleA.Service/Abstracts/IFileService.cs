using Microsoft.AspNetCore.Http;
using System.Net;
using TripleA.Data.Entities;

namespace TripleA.Service.Abstracts
{
    public interface IFileService
    {
        public Task<string> UploadFile(string location, IFormFile? file);

        public void SetQuestionFilePath(HttpStatusCode status, string fileUrl, Question question);

        public bool DeleteFile(string filePath);
    }
}
