using Microsoft.AspNetCore.Http;
using TripleA.Data.Entities;

namespace TripleA.Service.Abstracts
{
    public interface IQuestionService
    {
        Task<string> AddQuestion(Question question, IFormFile file);
        public Task<string> DeleteAsync(Question question);
        public Task<Question> GetByIDAsync(int id);
        public Task<string> EditAsync(Question question);
        public IQueryable<Question> GetQuestionsQuerable();

        public IQueryable<Question> FilliterQuestionsPaginatedQuerable(string search);

    }
}
