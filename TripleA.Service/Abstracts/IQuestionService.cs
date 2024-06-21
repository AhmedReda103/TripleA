using Microsoft.AspNetCore.Http;
using TripleA.Data.Entities;

namespace TripleA.Service.Abstracts
{
    public interface IQuestionService
    {
        Task<string> AddQuestion(Question question, IFormFile file);
        Task<string> DeleteAsync(Question question);
        Task<Question> GetByIDAsync(int id);
        Task<string> EditAsync(Question question);
        //Task<Question> GetQuestionWithAnswersAndCommentsAsync(int questionId, int answersLimit, int commentsLimit);
    }
}
