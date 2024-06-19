using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripleA.Data.Entities;
using TripleA.Infrustructure.Abstractions;
using TripleA.Infrustructure.unitOfWork;
using TripleA.Service.Abstracts;

namespace TripleA.Service.implementations
{

    public class AnswerService : IAnswerService
    {
        private readonly IUnitOfWork unitOfWork;

        public AnswerService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<string> AddAnswer(Answer answer)
        {
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
