
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics;
using TripleA.Data.Entities;
using TripleA.Infrustructure.unitOfWork;
using TripleA.Service.Abstracts;

namespace TripleA.Service.implementations
{

    public class AnswerService : IAnswerService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IFileService fileService;
        private readonly IPhotoService photoService;

        public AnswerService(IUnitOfWork unitOfWork, IFileService fileService, IPhotoService photoService)
        {
            this.unitOfWork = unitOfWork;
            this.fileService = fileService;
            this.photoService = photoService;
        }
        public async Task<string> AddAnswer(Answer answer, IFormFile file)
        {
            //var fileUrl = await fileService.UploadFile("Answer", file);

            var result = await photoService.AddPhotoAsync(file);


            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var fileUrl = result.Url.ToString();
                answer.Image = fileUrl;
            }
            else
            {
                answer.Image = "NoFile";
            }


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

        public async Task<string> DeleteAsync(Answer answer)
        {
            var trans = unitOfWork.Answers.BeginTransaction();
            try
            {
                unitOfWork.Answers.Delete(answer);
                await unitOfWork.SaveChangesAsync();
                await trans.CommitAsync();
                return "Success";
            }
            catch (Exception ex)
            {
                await trans.RollbackAsync();
                Debug.WriteLine(ex.Message);
                return "Falied";
            }
        }

        public async Task<string> getReplyerIdOfAnswer(int answerId)
        {
            var answer = await unitOfWork.Answers.GetByIdAsync(answerId);
            return answer.UserId;
        }

        public async Task<Answer> GetAnswerByIdAsync(int Id)
        {
            var answer = await unitOfWork.Answers.GetByIdAsync(Id);
            return answer;
        }

        public async Task<string> EditAsync(Answer answer)
        {
            try
            {
                unitOfWork.Answers.Update(answer);
                await unitOfWork.SaveChangesAsync();
                return "Success";
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return "Falied";
            }
        }

        public IQueryable<Answer> getAnswersByQuestionIdPaginatedQuerable(int questionId)
        {
            var Question = unitOfWork.Questions.GetTableNoTracking().AsQueryable().Where(v => v.Id == questionId);
            var Answers = unitOfWork.Answers.GetTableNoTracking().AsQueryable();
            if (!Question.IsNullOrEmpty() && !Answers.IsNullOrEmpty())
            {
                var query = from a in Question
                            join b in Answers on a.Id equals b.QuestionId
                            select new Answer
                            {
                                Id = b.Id,
                                Description = b.Description,
                                Image = b.Image,
                                CreatedIn = b.CreatedIn,
                                Votes = b.Votes,
                                UserId = b.UserId


                            };
                return query;
            }
            return Enumerable.Empty<Answer>().AsQueryable();
        }
    }
}
