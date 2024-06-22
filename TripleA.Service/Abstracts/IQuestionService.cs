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
        public IQueryable<Question> GetQuestionByTitleQuerable(string title);

        public IQueryable<Question> FilliterQuestionsPaginatedQuerable(string search);


        //Task<string> DeleteAsync(Question question);

        //Task<Question> GetByIDAsync(int id);
        //Task<string> EditAsync(Question question);

        // Task<Question> GetByIDAsync(int id);
        //   Task<string> EditAsync(Question question);

        //Task<Question> GetQuestionWithAnswersAndCommentsAsync(int questionId, int answersLimit, int commentsLimit);

    }
}
