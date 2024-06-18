using Microsoft.AspNetCore.Http;
using TripleA.Data.Entities;

namespace TripleA.Service.Abstracts
{
    public interface IAnswerService
    {
        Task<string> AddAnswer(Answer question, IFormFile file);
    }
}
