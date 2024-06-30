
using Microsoft.AspNetCore.Http;
using TripleA.Data.Entities;

namespace TripleA.Service.Abstracts
{
    public interface IAnswerService
    {

        Task<string> AddAnswer(Answer question, IFormFile? file = null);
        Task<Answer> getAnswerById(int answerId);
        Task Upvote(Answer answer);
        Task DownVote(Answer answer);
        public Task<string> DeleteAsync(Answer answer);
        Task<string> getReplyerIdOfAnswer(int answerId);
        Task<Answer> GetAnswerByIdAsync(int Id);
        public Task<string> EditAsync(Answer answer);
        IQueryable<Answer> getAnswersByQuestionIdPaginatedQuerable(int questionId);

        Task<IEnumerable<Answer>> GetAnswersOfUser(string userId);
    }
}
