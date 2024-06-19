using Microsoft.AspNetCore.Http;
using TripleA.Data.Entities;
using TripleA.Infrustructure.unitOfWork;
using TripleA.Service.Abstracts;


namespace TripleA.Service.implementations
{
    public class QuestionService : IQuestionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileService fileService;

        public QuestionService(IUnitOfWork unitOfWork, IFileService fileService)
        {

            _unitOfWork = unitOfWork;
            this.fileService = fileService;
        }
        public async Task<string> AddQuestion(Question question, IFormFile file)
        {
            var fileUrl = await fileService.UploadFile("Question", file);
            switch (fileUrl)
            {
                case "NoFile": return "NoFile";
                case "FailedToUploadFile": return "FailedToUploadFile";
            }
            question.Image = fileUrl;

            await _unitOfWork.Questions.AddAsync(question);
            await _unitOfWork.SaveChangesAsync();
            return "Added";
        }

    }
}
