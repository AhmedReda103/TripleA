
using Microsoft.AspNetCore.Http;
using TripleA.Data.Entities;


namespace TripleA.Service.Abstracts
{
    public interface IAnswerService
    {

        Task<string> AddAnswer(Answer question, IFormFile file);
        Task<Answer> getAnswerById(int answerId);
        Task Upvote(Answer answer);
        Task DownVote(Answer answer);
        public Task<string> DeleteAsync(Answer answer);
        Task<string> getReplyerIdOfAnswer(int answerId);

    }
}
