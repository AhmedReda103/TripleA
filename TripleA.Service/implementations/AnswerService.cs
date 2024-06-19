using Microsoft.AspNetCore.Http;
using TripleA.Data.Entities;
using TripleA.Infrustructure.unitOfWork;
using TripleA.Service.Abstracts;

namespace TripleA.Service.implementations
{

    public class AnswerService : IAnswerService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IFileService fileService;

        public AnswerService(IUnitOfWork unitOfWork, IFileService fileService)
        {
            this.unitOfWork = unitOfWork;
            this.fileService = fileService;
        }
        public async Task<string> AddAnswer(Answer answer, IFormFile file)
        {
            var fileUrl = await fileService.UploadFile("Answer", file);
            switch (fileUrl)
            {
                case "NoFile": return "NoFile";
                case "FailedToUploadFile": return "FailedToUploadFile";
            }
            answer.Image = fileUrl;

            await unitOfWork.Answers.AddAsync(answer);
            await unitOfWork.SaveChangesAsync();
            return "Added";
        }

        public async Task<Answer> getAnswerById(int answerId)
        {
            return await unitOfWork.Answers.GetByIdAsync(answerId);
        }

        public async Task Upvote(Answer answer)
        {
             answer.Votes++;
             await unitOfWork.SaveChangesAsync();
        }

        public async Task DownVote(Answer answer)
        {
            answer.Votes--;
            await unitOfWork.SaveChangesAsync();
        }
    }
}
